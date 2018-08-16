using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventPledgesHandler  : ICommandHandler<EventPledgesQuery, EventPledges>
    {
        public Task<EventPledges> ExecuteAsync(EventPledgesQuery command, EventPledges previousResult)
        {
            throw new System.NotImplementedException();
        }
    }
}