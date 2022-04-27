using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Proje.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(_productService.GetProductsWithCategory());
        }

        public IActionResult Update([FromRoute] int id)
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View(_productService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update([FromForm] Product product)
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            _productService.Update(product);
            return RedirectToAction();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Product product)
        {
            _productService.Add(product);
            return RedirectToAction();
        }
    }
}
