using Dani.Business;
using Dani.Models.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace DaniWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> objCategoryList = categoryService.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryModel obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                categoryService.Create(obj);
                
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        // GET
        public IActionResult Edit(int id)
        {
            CategoryViewModel categoryFromDb = categoryService.GetById(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost] //PUT
        public IActionResult Edit(UpdateCategoryModel obj)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(obj);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id) //GET
        {
            object categoryToDelete = categoryService.GetById(id);

            if (categoryToDelete == null)
            {
                return NotFound();
            }

            return View(categoryToDelete);
        }

        [HttpPost, ActionName("Delete")] // DELETE
        public IActionResult DeletePOST(int id)
        {
            categoryService.Delete(id);

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}