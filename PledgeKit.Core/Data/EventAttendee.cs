using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class EventAttendee
    {
        public bool InActive { get; set; }
        public bool ShareEmailWithProjects { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid EventId { get; set; }
        public Guid AttendeeId { get; set; }
        public int ClusterKey { get; set; }

        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
    }
}
