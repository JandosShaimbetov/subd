﻿using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Position1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
