using Hangfire;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Data;
using Mimisbrunnr.Services.Interfaces;
using System.Text;

namespace Mimisbrunnr.Services.Instances
{
    public class JobService : IJobService
    {
        private readonly Context _context;

        public JobService(Context context)
        {
            _context = context;
        }

        public async Task<bool> ScheduleEventPostToDiscord(Guid eventGuid, Guid? webhookGuid, DateTime? date, string? discordDescription = null)
        {
            var dbEvent = await _context.Event.SingleOrDefaultAsync(e => e.Guid == eventGuid) ?? throw new ArgumentException($"No event with Guid {eventGuid} found!");

            // We don't want to push this to Discord anymore
            if (!webhookGuid.HasValue)
            {
                BackgroundJob.Delete(dbEvent.JobId);
                dbEvent.JobId = null;
                await _context.SaveChangesAsync();
                return true;
            }

            var webhook = await _context.Webhooks.SingleOrDefaultAsync(w => w.Guid == webhookGuid.Value) ?? throw new ArgumentException($"No webhook with Guid {webhookGuid} found!");

            // Event has already started, we don't allow posting anymore
            if (dbEvent.StartDate < DateTime.Now)
                return false;

            // Use specified description, else fallback to Discord specific value stored in DB, else just use general description
            var description = discordDescription ?? dbEvent.DiscordDescription ?? dbEvent.Description;

            // If we want to reschedule, we need to delete the old job first, then just reschedule it as if it were a new job
            // By treating it as a new job, we can easily fire it immediately as well
            if (dbEvent.JobId != null)
                BackgroundJob.Delete(dbEvent.JobId);

            string jobId =
                date.HasValue
                ? BackgroundJob.Schedule(() => PostToDiscordWithWebhook(webhook.Hook, description, dbEvent.Id), date.Value - DateTime.Now)
                : BackgroundJob.Enqueue(() => PostToDiscordWithWebhook(webhook.Hook, description, dbEvent.Id));
            dbEvent.JobId = jobId;

            // If nothing has changed, no new job was rescheduled and it failed.
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task PostToDiscordWithWebhook(string url, string description, int eventId)
        {
            using var client = new HttpClient();
            try
            {
                var payload = new { content = description };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                // Check the response status if needed
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Webhook call successful!");
                    var ev = await _context.Event.SingleAsync(e => e.Id == eventId);
                    ev.IsPostedToDiscord = true;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Webhook call failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
