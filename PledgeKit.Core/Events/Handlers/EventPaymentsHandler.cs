using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Models;

namespace PledgeKit.Core.Events.Handlers
{
    public class EventPaymentsHandler : ICommandHandler<EventPaymentsQuery, EventPayments>
    {
        public Task<EventPayments> ExecuteAsync(EventPaymentsQuery command, EventPayments previousResult)
        {
            throw new System.NotImplementedException();
        }
    }
}