using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Raw
    {
        public Raw()
        {
            Ingredients = new HashSet<Ingredient>();
            RawPurchases = new HashSet<RawPurchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Unit { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<RawPurchase> RawPurchases { get; set; }
    }
}
