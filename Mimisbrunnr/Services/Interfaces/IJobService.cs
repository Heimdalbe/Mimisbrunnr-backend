namespace Mimisbrunnr.Services.Interfaces
{
    public interface IJobService
    {
        public Task<bool> ScheduleEventPostToDiscord(Guid eventGuid, Guid? webhookGuid, DateTime? date, string? description = null);
    }
}
