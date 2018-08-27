using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Commands;

namespace PledgeKit.Core.Events.Validation
{
    public class EventExistsValidator : IEventExistsValidator
    {
        private readonly PledgeKitContext _context;

        public EventExistsValidator(PledgeKitContext context)
        {
            _context = context;
        }

        public async Task<ValidateEventResult> ValidateEvent(CreateEditEventCommandBase model)
        {
            var result = new ValidateEventResult
            {
                EventExists = await
                    _context.Events
                        .AnyAsync(
                            x =>
                                x.EventDate.Date == model.EventDate.Date &&
                                x.Name.ToLower() == model.Name.ToLower())
            };


            if (result.EventExists)
            {
                result.Message =
                    $"There is already an event called {model.Name} on the same date";
            }

            return result;
        }
    }
}
