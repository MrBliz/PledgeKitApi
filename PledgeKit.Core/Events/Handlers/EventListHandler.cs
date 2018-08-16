using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventListHandler :ICommandHandler<EventListQuery, EventList>
    {
        public Task<EventList> ExecuteAsync(EventListQuery command, EventList previousResult)
        {
            throw new NotImplementedException();
        }
    }
}
