using Mimmisbrunnr.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Infrastructure.Services.Interfaces
{
    public interface IActivityService
    {
        // COMMON GET METHODS
        public Task<IEnumerable<Activity>> GetAllAsync();
        public Task<IEnumerable<Activity>> GetOverviewAsync(int amount);
        public Task<Activity> GetByIdAsync(long id);
        public Task<Activity> CreateAsync(Activity activity);
        public Task<Activity> Update(long id, Activity DTO);
        public Task<Activity> DeleteAsync(long id);
    }
}
