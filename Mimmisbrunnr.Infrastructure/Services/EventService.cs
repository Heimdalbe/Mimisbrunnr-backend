using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Domain.Event;
using Mimmisbrunnr.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Mimmisbrunnr.Infrastructure.Services
{
    public class EventService: IService
    {
        private readonly EventStoreContext _eventStoreContext;

        public EventService(EventStoreContext eventStoreContext)
        {
            _eventStoreContext = Guard.Against.Null(eventStoreContext, nameof(eventStoreContext));
        }

        public async Task<IEnumerable<Event>> GetAllAsync<Event>()
        {
            return (IEnumerable<Event>) await _eventStoreContext.Locations.ToListAsync();
        }


        public Task<T> Delete<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T, U>(Guid id, U DTO)
        {
            throw new NotImplementedException();
        }
    }
}
