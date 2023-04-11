using System;
using System.Collections.Generic;

#nullable disable

namespace subd
{
    public partial class Product
    {
        public Product()
        {
            Ingredients = new HashSet<Ingredient>();
            ProductSales = new HashSet<ProductSale>();
            Productions = new HashSet<Production>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Unit { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
    }
}
