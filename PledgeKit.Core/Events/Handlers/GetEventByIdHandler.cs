using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class GetEventByIdHandler : ICommandHandler<EventQuery, EventModel>
    {
        private readonly IContextProvider _context;

        public GetEventByIdHandler(IContextProvider context)
        {
            _context = context;
        }

        public async Task<EventModel> ExecuteAsync(EventQuery query, EventModel previousResult)
        {   
            return new EventModel();
            //var @event = await _context.Events.FindAsync(command.EventId);

            //return @event.Adapt(new EventModel());
        }
    }

}
