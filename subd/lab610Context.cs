using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace subd
{
    public partial class lab610Context : DbContext
    {
        public lab610Context()
        {
        }

        public lab610Context(DbContextOptions<lab610Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSale> ProductSales { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<Raw> Raws { get; set; }
        public virtual DbSet<RawPurchase> RawPurchases { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<VBonu> VBonus { get; set; }
        public virtual DbSet<VBudget> VBudgets { get; set; }
        public virtual DbSet<VEmployee> VEmployees { get; set; }
        public virtual DbSet<VEmployeeSalary> VEmployeeSalaries { get; set; }
        public virtual DbSet<VIngredient> VIngredients { get; set; }
        public virtual DbSet<VPercent> VPercents { get; set; }
        public virtual DbSet<VPosition> VPositions { get; set; }
        public virtual DbSet<VProduct> VProducts { get; set; }
        public virtual DbSet<VProductSale> VProductSales { get; set; }
        public virtual DbSet<VProduction> VProductions { get; set; }
        public virtual DbSet<VRaw> VRaws { get; set; }
        public virtual DbSet<VRawPurchase> VRawPurchases { get; set; }
        public virtual DbSet<VUnit> VUnits { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-47H9CRM\\MSSQLSERVER01;Database=lab6-10;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("Budget");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bonus).HasColumnName("bonus");

                entity.Property(e => e.BudgetAmount).HasColumnName("budget_amount");

                entity.Property(e => e.Percent).HasColumnName("percent");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.ToTable("EmployeeSalary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Bonusamount).HasColumnName("bonusamount");

                entity.Property(e => e.Done).HasColumnName("done");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Production).HasColumnName("production");

                entity.Property(e => e.Productsales).HasColumnName("productsales");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rawpurchase).HasColumnName("rawpurchase");

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_EmployeeSalary_Employees");

                entity.HasOne(d => d.MonthNavigation)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.Month)
                    .HasConstraintName("FK_EmployeeSalary_Months");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Raw).HasColumnName("raw");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingredients_Products");

                entity.HasOne(d => d.RawNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Raw)
                    .HasConstraintName("FK_Ingredients_Raw");
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Month1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("month");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Position1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Products_Units");
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.ToTable("Product_Sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Product_Sales_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ProductSales)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Product_Sales_Products");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.ToTable("production");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_production_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_production_Products");
            });

            modelBuilder.Entity<Raw>(entity =>
            {
                entity.ToTable("Raw");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Raws)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Raw_Units");
            });

            modelBuilder.Entity<RawPurchase>(entity =>
            {
                entity.ToTable("Raw_Purchase");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee).HasColumnName("employee");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Raw).HasColumnName("raw");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.RawPurchases)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Raw_Purchase_Employees");

                entity.HasOne(d => d.RawNavigation)
                    .WithMany(p => p.RawPurchases)
                    .HasForeignKey(d => d.Raw)
                    .HasConstraintName("FK_Raw_Purchase_Raw");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<VBonu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_bonus");

                entity.Property(e => e.Bonus).HasColumnName("bonus");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<VBudget>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_budget");

                entity.Property(e => e.BudgetAmount).HasColumnName("budget_amount");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<VEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_employees");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<VEmployeeSalary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_employeeSalary");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Bonusamount).HasColumnName("bonusamount");

                entity.Property(e => e.Done).HasColumnName("done");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Month)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("month");

                entity.Property(e => e.Production).HasColumnName("production");

                entity.Property(e => e.Productsales).HasColumnName("productsales");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rawpurchase).HasColumnName("rawpurchase");

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<VIngredient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_ingredients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Product)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Raw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raw");
            });

            modelBuilder.Entity<VPercent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_percent");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Percent).HasColumnName("percent");
            });

            modelBuilder.Entity<VPosition>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_positions");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<VProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_products");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<VProductSale>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_product_sales");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Product)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<VProduction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_production");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Product)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<VRaw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_raw");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<VRawPurchase>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_raw_purchase");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Raw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raw");
            });

            modelBuilder.Entity<VUnit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_units");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Year1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
