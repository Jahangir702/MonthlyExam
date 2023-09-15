using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MonthlyExam.Models
{
    public enum SellUnit { kg = 1, g, mg, l, ml, nos }
    public class Product
    {
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;

        [Required, StringLength(100)]
        public string Picture { get; set; } = default!;

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(SellUnit))]
        public SellUnit SellUnit { get; set; }

        public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
    public class ProductInventory
    {
        public int ProductInventoryId { get; set; }

        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; } = default!;
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductInventory> ProductInventories { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Pototo", UnitPrice = 900.00M, SellUnit = SellUnit.kg, Picture = "1.jpg" }
                );
            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductInventoryId = 1, Date = DateTime.Now.AddDays(-10), Quantity = 100, ProductId = 1 },
                new ProductInventory { ProductInventoryId = 2, Date = DateTime.Now.AddDays(-10), Quantity = 20, ProductId = 1 }
                );
        }
    }
}
