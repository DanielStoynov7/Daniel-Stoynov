using Dani.Models.Models.CategoryModels;
using DaniWeb.Data;
using DaniWeb.Models;

namespace Dani.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CreateCategoryModel model)
        {
            var entity = this.MapCreateModelToEntity(model);
            this.dbContext.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = this.dbContext.Categories.Find(id);
            if (category is null)
            {
                throw new Exception("Not Found");
            }

            this.dbContext.Categories.Remove(category);
            this.dbContext.SaveChanges();
        }

        public List<CategoryViewModel> GetAll()
        {
            return this.dbContext.Categories.Select(this.MapEntityToModel).ToList();
        }

        public CategoryViewModel? GetById(int id)
        {
            var category = this.dbContext.Categories.Find(id);

            return MapEntityToModel(category);
        }

        public void Update(UpdateCategoryModel model)
        {
            var category = this.dbContext.Categories.Find(model.Id);

            if (category is null)
            {
                throw new Exception("Not found");
            }

            category.Name = model.Name;
            category.DisplayOrder = model.DisplayOrder;

            this.dbContext.Update(category);
            this.dbContext.SaveChanges();
        }

        private CategoryEntity MapCreateModelToEntity(CreateCategoryModel model)
        {
            if (model is null)
            {
                return null;
            }

            return new CategoryEntity { Name = model.Name, DisplayOrder = model.DisplayOrder };
        }

        private CategoryViewModel MapEntityToModel(CategoryEntity category)
        {
            if (category is null)
            {
                return null;
            }

            return new CategoryViewModel { Id = category.Id, Name = category.Name, DisplayOrder = category.DisplayOrder };
        }
    }
}
