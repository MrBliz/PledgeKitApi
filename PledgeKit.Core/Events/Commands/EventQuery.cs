using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Commands
{
    public class EventQuery : EventId,  ICommand<EventModel>
    {
    }
}
