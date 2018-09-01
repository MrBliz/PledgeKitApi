using System.Threading.Tasks;
using PledgeKit.Core.Data;
using PledgeKit.Core.Events.Commands;
using PledgeKit.Core.Events.Validation;
using Shouldly;
using Xunit;

namespace PledgeKit.UnitTests.Events
{
    public class EventValidatorTests
    {
        private readonly PledgeKitContext _context;

        [Fact]
        public async Task EventExists_Should_Be_True_If_Event_With_Same_Name_Exists_On_Same_Day()
        {
            var validator = new EventExistsValidator(_context);

            var model = new CreateEditEventCommandBase { };


            var result = await validator.ValidateEvent(model);

            result.EventExists.ShouldBe(true);
        }
    }
}
