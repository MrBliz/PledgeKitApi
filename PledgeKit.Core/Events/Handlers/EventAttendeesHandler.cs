using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventAttendeesHandler : ICommandHandler<EventAttendeeQuery, EventAttendees>
    {
        private readonly IContextProvider _context;

        public EventAttendeesHandler(IContextProvider context)
        {
            _context = context;
        }
        
        public Task<EventAttendees> ExecuteAsync(EventAttendeeQuery command, EventAttendees previousResult)
        {
            throw new System.NotImplementedException();
        }
        
    }
    
}
