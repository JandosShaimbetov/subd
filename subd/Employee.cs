using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            ProductSales = new HashSet<ProductSale>();
            Productions = new HashSet<Production>();
            RawPurchases = new HashSet<RawPurchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Position { get; set; }
        public double? Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Position PositionNavigation { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<RawPurchase> RawPurchases { get; set; }
    }
}
