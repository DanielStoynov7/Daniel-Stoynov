using Dani.Models.Models.CategoryModels;

namespace Dani.Models.Models.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public required int CategoryId { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
