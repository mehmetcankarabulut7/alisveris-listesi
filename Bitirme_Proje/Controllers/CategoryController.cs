using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Proje.Controllers
{
    [Authorize(Roles="admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(_categoryService.GetAll());
        }

        public IActionResult Update([FromRoute] int id)
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(_categoryService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update([FromForm] Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(); ;
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            if (_categoryService.GetByName(category.Name) != null)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View(category);
            }

            _categoryService.Add(category);
            return RedirectToAction();
        }
    }
}
