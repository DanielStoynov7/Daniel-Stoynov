using Dani.DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DaniWeb.Models
{
    public class CategoryEntity
    {
        [Key] // анотация
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public required string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 - 100")]
        public int DisplayOrder { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
