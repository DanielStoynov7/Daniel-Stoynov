using Dani.Business;
using Dani.Models.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace DaniWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = this.productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel createProduct)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
