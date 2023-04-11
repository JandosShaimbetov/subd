using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class VProductSale
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int? Quantity { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string Employee { get; set; }
    }
}
