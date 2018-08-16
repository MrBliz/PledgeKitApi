using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class Payment
    {
        public int PaymentMethodId { get; set; }
        public int FilanthropyEventId { get; set; }
        public decimal Amount { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid PaymentId { get; set; }
        public Guid AttendeeId { get; set; }
        public Guid EventId { get; set; }
        public int ClusterKey { get; set; }

        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
