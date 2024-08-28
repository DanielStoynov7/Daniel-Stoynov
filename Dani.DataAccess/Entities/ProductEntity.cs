using DaniWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dani.DataAccess.Entities
{
    public class ProductEntity
    {
        //[Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

    }
}
