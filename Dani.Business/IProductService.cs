using Dani.Models.Models.Products;

namespace Dani.Business
{
    public interface IProductService
    {
        void Create(CreateProductModel createProductModel);

        void Update(UpdateProductModel update);

        void Delete(int id);

        IEnumerable<ProductViewModel> GetAll();

        ProductViewModel GetProduct(int id);

        IEnumerable<ProductViewModel> GetByCategory(int categoryId);
    }
}
