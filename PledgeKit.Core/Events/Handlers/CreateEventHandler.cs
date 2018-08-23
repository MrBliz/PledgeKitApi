using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class CreateEventHandler : ICommandHandler<CreateEventCommand, EventModel>
    {
        public Task<EventModel> ExecuteAsync(CreateEventCommand command, EventModel previousResult)
        {
            throw new NotImplementedException();
        }
    }
}
