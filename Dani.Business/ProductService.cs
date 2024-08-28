using Dani.DataAccess.Entities;
using Dani.Models.Models.CategoryModels;
using Dani.Models.Models.Products;
using DaniWeb.Data;

namespace Dani.Business
{
    public class ProductService : IProductService
    {
        private List<ProductViewModel> products;

        public ProductService()
        {
            products = new List<ProductViewModel>() { new ProductViewModel { Id = 1, CategoryId = 1, Category = new CategoryViewModel { Id = 4, Name = "Horror", DisplayOrder = 4 }, Name = "Saw"} };
        }

        public void Create(CreateProductModel createProductModel)
        {
            var category = products.Where(product => product.Category.Id == createProductModel.CategoryId).Select(product => product.Category).FirstOrDefault();

            if (category == null)
            {
                throw new Exception("Not found");
            }

            var product = new ProductViewModel { CategoryId = category.Id, Category = category, Id = products.Count() + 1, Name = createProductModel.Name };

            products.Add(product);
        }

        public void Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                throw new Exception("Not found");  
            }

            products.Remove(product);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return products;
        }

        public IEnumerable<ProductViewModel> GetByCategory(int categoryId)
        {
            var product = products.Find(product => product.CategoryId == categoryId);

            if (product == null)
            {
                throw new Exception("Not found");
            }

            return products;
        }

        public ProductViewModel? GetProduct(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            return product;
        }

        public void Update(UpdateProductModel update)
        {
            var product = products.Find(product => product.Id == update.Id);

            if (product is null)                                        
            {
                throw new Exception("Not found");
            }

            product.Name = update.Name;
            product.CategoryId = update.CategoryId;
            
        }

        private ProductEntity MapCreateProductModel(CreateProductModel product)
        {
            if (product is null)
            {
                return null;
            }

            return new ProductEntity { Name = product.Name, CategoryId = product.CategoryId };
        }
    }
}
