using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class VRaw
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
    }
}
