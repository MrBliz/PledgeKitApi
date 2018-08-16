using System;
using System.Collections.Generic;

namespace PledgeKit.Data
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDoorPaymentMethod { get; set; }
        public int SortOrder { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
