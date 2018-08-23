using System;
using System.Collections.Generic;
using PledgeKit.Core.Projects;

namespace PledgeKit.Core.Events.Models
{
    public class EventModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EntryFee { get; set; }
        public decimal Target { get; set; }
        public decimal EventLevy { get; set; }

        public List<ProjectModel> Projects { get; set; }
        public int ProjectCount { get; set; }

        public int TotalAttendees { get; set; }
        // TODO : Implement when EfCore gets Date Functions 
        //public int NewAttendees { get; set; }

        public decimal TotalPledged { get; set; }
        public int PledgeCount { get; set; }

        public decimal TotalPayments { get; set; }
        public int PaymentCount { get; set; }
    }
}
