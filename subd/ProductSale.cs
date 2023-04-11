using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class ProductSale
    {
        public int Id { get; set; }
        public int? Product { get; set; }
        public int? Quantity { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
