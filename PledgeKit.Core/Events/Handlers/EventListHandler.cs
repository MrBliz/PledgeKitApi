using System;
using System.Linq;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventListHandler :ICommandHandler<EventListQuery, EventList>
    {
        private readonly PledgeKitContext _context;

        public async Task<EventList> ExecuteAsync(EventListQuery command, EventList previousResult)
        {
            var query = _context.Events.AsQueryable();

            if(!string.IsNullOrWhiteSpace(command.Filter)){
                query = query.Where(x=>x.Name.ToLower().Contains(command.Filter.ToLower()));
            }

            var eventList = new EventList{
                Events = await  query.Take(command.PageSize)
                                        .ProjectToType<EventModel>()
                                        .ToListAsync()  
                                    };
            return eventList;
        }
    }
}
