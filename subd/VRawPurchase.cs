﻿using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class VRawPurchase
    {
        public int Id { get; set; }
        public string Raw { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string Employee { get; set; }
    }
}
