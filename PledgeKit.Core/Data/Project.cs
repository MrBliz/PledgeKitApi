using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class Project
    {
        public Project()
        {
            EventProjects = new HashSet<EventProject>();
            Pledges = new HashSet<Pledge>();
        }

        public string Name { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid ProjectId { get; set; }
        public int ClusterKey { get; set; }

        public ICollection<EventProject> EventProjects { get; set; }
        public ICollection<Pledge> Pledges { get; set; }
    }
}
