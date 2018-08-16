using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Attendees.Commands;
using PledgeKit.Core.Attendees.Models;

namespace PledgeKit.Core.Attendees.Handlers
{
    public class GetAttendeeByIdHandler :ICommandHandler<AttendeeQuery, AttendeeModel>
    {
        public Task<AttendeeModel> ExecuteAsync(AttendeeQuery command, AttendeeModel previousResult)
        {
            throw new NotImplementedException();
        }
    }
}
