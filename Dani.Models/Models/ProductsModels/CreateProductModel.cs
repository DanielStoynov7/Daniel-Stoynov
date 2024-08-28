using System.ComponentModel.DataAnnotations;

namespace Dani.Models.Models.Products
{
    public class CreateProductModel
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required int CategoryId { get; set; }
    }
}
