using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Domain.Activities;
using Mimmisbrunnr.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using Mimmisbrunnr.Infrastructure.Services.Interfaces;
using Mimmisbrunnr.Infrastructure.Exceptions;

namespace Mimmisbrunnr.Infrastructure.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ActivityStoreContext _activityStoreContext;

        public ActivityService(ActivityStoreContext eventStoreContext)
        {
            _activityStoreContext = Guard.Against.Null(eventStoreContext, nameof(eventStoreContext));
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _activityStoreContext.Events
                .Where(activity => !activity.IsDeleted)
                .Include(activity => activity.Location)
                .Include(activity => activity.Banner)
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetOverviewAsync(int amount)
        {
            if (amount > 0)
                return await _activityStoreContext.Events
                    .Where(activity => !activity.IsDeleted)
                    .Include(activity => activity.Banner)
                    .OrderBy(activity => activity.Start)
                    .Take(amount)
                    .ToListAsync();
            else
                return await _activityStoreContext.Events
                    .Where(activity => !activity.IsDeleted)
                    .Include(activity => activity.Banner)
                    .OrderBy(activity => activity.Start)
                    .ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(long id)
        {
            var activity = await _activityStoreContext.Events
                .Include(activity => activity.Location)
                .Include(activity => activity.Banner)
                .FirstOrDefaultAsync(activity => activity.Id == id);

            if(activity == null)
            {
                throw new EntityNotFoundException($"Could not find Activity with Id: {id}");
            }

            return activity;
        }

        public Task<Activity> Update(long id, Activity DTO)
        {
            throw new NotImplementedException();
        }


        public async Task<Activity> DeleteAsync(long id)
        {
            var toBeDeleted = await _activityStoreContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (toBeDeleted == null)
                throw new EntityNotFoundException($"Could not find Activity with Id: {id}");

            toBeDeleted.IsDeleted = true;
            toBeDeleted.TimeUpdated = DateTime.UtcNow;

            await _activityStoreContext.SaveChangesAsync();
            
            return toBeDeleted;
        }

        
    }
}
