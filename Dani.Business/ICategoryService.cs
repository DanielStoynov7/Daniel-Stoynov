using Dani.Models.Models.CategoryModels;

namespace Dani.Business
{
    public interface ICategoryService
    {
        void Delete(int id);

        void Update(UpdateCategoryModel model);

        void Create(CreateCategoryModel model);

        CategoryViewModel GetById(int id);

        List<CategoryViewModel> GetAll();
    }
}
