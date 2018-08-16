using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class EventProject
    {
        public Guid EventId { get; set; }
        public Guid ProjectId { get; set; }
        public int ClusterKey { get; set; }

        public Event Event { get; set; }
        public Project Project { get; set; }
    }
}
