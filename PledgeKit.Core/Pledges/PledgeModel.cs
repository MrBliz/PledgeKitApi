using System;
using System.Collections.Generic;
using System.Text;

namespace PledgeKit.Core.Pledges
{
    public class PledgeModel
    {
        public Guid PledgeId { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal? Amount { get; set; }
        public DateTime PledgeDate { get; set; }
    }
}
