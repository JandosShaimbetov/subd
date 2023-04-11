using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class RawPurchase
    {
        public int Id { get; set; }
        public int? Raw { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Raw RawNavigation { get; set; }
    }
}
