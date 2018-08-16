using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Attendees.Models;

namespace PledgeKit.Core.Attendees.Commands
{
    public class AttendeeQuery :AttendeeId, ICommand<AttendeeModel>
    {
    }
}
