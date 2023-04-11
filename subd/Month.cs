using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Month
    {
        public Month()
        {
            EmployeeSalaries = new HashSet<EmployeeSalary>();
        }

        public int Id { get; set; }
        public string Month1 { get; set; }

        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
    }
}
