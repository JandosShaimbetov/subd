using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class VEmployeeSalary
    {
        public int Id { get; set; }
        public string Employee { get; set; }
        public int? Rawpurchase { get; set; }
        public int? Production { get; set; }
        public int? Productsales { get; set; }
        public int? Quantity { get; set; }
        public double? Bonusamount { get; set; }
        public double? Amount { get; set; }
        public bool? Done { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
}
