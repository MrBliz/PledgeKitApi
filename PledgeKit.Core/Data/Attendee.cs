using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class Attendee
    {
        public Attendee()
        {
            EventAttendees = new HashSet<EventAttendee>();
            Payments = new HashSet<Payment>();
            Pledges = new HashSet<Pledge>();
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool MailingList { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid AttendeeId { get; set; }
        public int ClusterKey { get; set; }

        public ICollection<EventAttendee> EventAttendees { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Pledge> Pledges { get; set; }
    }
}
