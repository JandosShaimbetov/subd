using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class VIngredient
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Raw { get; set; }
        public double? Quantity { get; set; }
    }
}
