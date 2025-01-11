using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Infrastructure.Services
{
    public interface IService
    {
        // COMMON GET METHODS
        public Task<IEnumerable<T>> GetAllAsync<T>();
        public Task<T> GetById<T>(Guid id);

        public Task<T> Update<T, U>(Guid id, U DTO);

        public Task<T> Delete<T>(Guid id);

    }
}
