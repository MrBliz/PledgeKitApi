using System.Threading.Tasks;
using PledgeKit.Core.Events.Commands;

namespace PledgeKit.Core.Events.Validation
{
    public interface IEventExistsValidator
    {
        Task<ValidateEventResult> ValidateEvent(CreateEditEventCommandBase model);
    }
}