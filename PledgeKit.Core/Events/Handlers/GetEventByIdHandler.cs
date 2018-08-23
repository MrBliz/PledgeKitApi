using System.Linq;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.EntityFrameworkCore;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class GetEventByIdHandler : ICommandHandler<EventQuery, EventModel>
    {
        private readonly PledgeKitContext _context;

        public GetEventByIdHandler(PledgeKitContext context)
        {
            _context = context;
        }

        public async Task<EventModel> ExecuteAsync(EventQuery query, EventModel previousResult)
        {
            return await _context.Events
                .Where(x=>x.EventId == query.Id)
                .BuildEventModel()
                .FirstOrDefaultAsync();
        }
    }
}
