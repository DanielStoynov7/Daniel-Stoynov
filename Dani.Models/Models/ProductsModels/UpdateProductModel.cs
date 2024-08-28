using System.ComponentModel.DataAnnotations;

namespace Dani.Models.Models.Products
{
    public class UpdateProductModel
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public required string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
