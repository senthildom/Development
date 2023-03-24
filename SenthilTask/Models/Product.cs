using System.ComponentModel.DataAnnotations;
namespace SenthilTask.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "ProductName Required!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "ProductQuantity Required!")]
        public int ProductQuantity { get; set; }
        [Required(ErrorMessage = "ProductPrice Required!")]
        public Decimal ProductPrice { get; set; }

    }
}
