using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Budget
    {
        public int Id { get; set; }
        public double? BudgetAmount { get; set; }
        public double? Percent { get; set; }
        public double? Bonus { get; set; }
    }
}
