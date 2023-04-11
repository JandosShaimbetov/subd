using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
            Raws = new HashSet<Raw>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Raw> Raws { get; set; }
    }
}
