using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class Event
    {
        public Event()
        {
            EventAttendees = new HashSet<EventAttendee>();
            EventProjects = new HashSet<EventProject>();
            Payments = new HashSet<Payment>();
            Pledges = new HashSet<Pledge>();
        }

        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Target { get; set; }
        public decimal EntryFee { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public decimal EventLevy { get; set; }
        public Guid EventId { get; set; }
        public int ClusterKey { get; set; }

        public ICollection<EventAttendee> EventAttendees { get; set; }
        public ICollection<EventProject> EventProjects { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Pledge> Pledges { get; set; }
    }
}
