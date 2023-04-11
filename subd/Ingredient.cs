using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public int? Product { get; set; }
        public int? Raw { get; set; }
        public double? Quantity { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual Raw RawNavigation { get; set; }
    }
}
