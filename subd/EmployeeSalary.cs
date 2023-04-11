using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class EmployeeSalary
    {
        public int Id { get; set; }
        public int? Employee { get; set; }
        public int? Rawpurchase { get; set; }
        public int? Production { get; set; }
        public int? Productsales { get; set; }
        public int? Quantity { get; set; }
        public double? Bonusamount { get; set; }
        public double? Amount { get; set; }
        public bool? Done { get; set; }
        public int? Month { get; set; }
        public string Year { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Month MonthNavigation { get; set; }
    }
}
