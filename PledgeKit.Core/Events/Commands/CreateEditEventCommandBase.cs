using System;

namespace PledgeKit.Core.Events.Commands
{
    public class CreateEditEventCommandBase
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EntryFee { get; set; }
        public decimal Target { get; set; }
        public decimal EventLevy { get; set; }
    }
}
