using System;
using System.Linq;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.EntityFrameworkCore;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;
using PledgeKit.Core.Projects;
using PledgeKit.Data;
using static System.String;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventListHandler :ICommandHandler<EventListQuery, EventList>
    {
        private readonly PledgeKitContext _context;

        public EventListHandler(PledgeKitContext context)
        {
            _context = context;
        }

        public async Task<EventList> ExecuteAsync(EventListQuery command, EventList previousResult)
        {
            var query = _context.Events.AsQueryable();

            if(!IsNullOrWhiteSpace(command.Filter)){
                query = query.Where(x=>x.Name.ToLower().Contains(command.Filter.ToLower()));
            }

            if (!IsNullOrWhiteSpace(command.SortColumn))
            {
                if (string.Equals(command.SortColumn, nameof(Event.Name), StringComparison.InvariantCultureIgnoreCase))
                {
                    query = command.Descending
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                }
                else
                {
                    query = command.Descending
                        ? query.OrderByDescending(x => x.EventDate)
                        : query.OrderBy(x => x.EventDate);
                }
            }

            var eventList = new EventList{
                Events = await  query.Take(command.PageSize)
                    .BuildEventModel()

                    .ToListAsync()
                                    };
            return eventList;
        }
    }
}
