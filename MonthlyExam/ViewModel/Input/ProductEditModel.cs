using MonthlyExam.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MonthlyExam.ViewModel.Input
{
    public class ProductEditModel
    {
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;

        public IFormFile? Picture { get; set; } = default!;

        [Required]
        [DataType(DataType.Currency), Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(SellUnit)), Display(Name = "Sold by")]
        public SellUnit SellUnit { get; set; }

        public virtual List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
}
