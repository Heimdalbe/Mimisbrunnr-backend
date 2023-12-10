
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Data
{
    public class DataInit
    {
        private readonly Context _context;
        private readonly Guid _webhookGuid = Guid.Parse("99abe08a-05c5-4ec0-8fa8-90eea2bb2bd0");
        private readonly Guid _memberGuid = Guid.Parse("bbc86f38-1be5-40cc-a21d-b7b3e118f4f0");

        public DataInit(Context context)
        {
            _context = context;
        }

        public async Task Init()
        {
            await _context.Database.EnsureDeletedAsync();
            if (await _context.Database.EnsureCreatedAsync())
            {
                await SeedData();
            }
        }

        private async Task SeedData()
        {

            var webhook = new DiscordWebhook { Guid = _webhookGuid, Hook = "https://discord.com/api/webhooks/1178038871498428416/5U4VpxUZiK3FtJEZem6DdWGF1fHqjWjhBZhwCO2BK5XGnowXihZTSjuBueLo6Wsl6tSC" };
            _context.Webhooks.Add(webhook);
            await _context.SaveChangesAsync();

            var year = new PraesidiumYear { Guid = Guid.NewGuid(), StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1)) };
            var function = new PraesidiumFunction { Guid = Guid.NewGuid(), Name = "Cultuur", Order = 0 };
            _context.PraesidiumYear.Add(year);
            _context.PraesidiumFunction.Add(function);
            await _context.SaveChangesAsync();

            var dbYear = await _context.PraesidiumYear.SingleAsync();
            var dbFunc = await _context.PraesidiumFunction.SingleAsync();

            var member = new PraesidiumMember { Guid = _memberGuid, Function = dbFunc, Year = dbYear, PictureUrl = "" };
            _context.PraesidiumMember.Add(member);
            await _context.SaveChangesAsync();
        }
    }
}
