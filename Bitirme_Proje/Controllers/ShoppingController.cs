using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Proje.Controllers
{
    public class ShoppingController : Controller
    {
        private IShoppingListService _shoppingListService;
        public ShoppingController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        public IActionResult Index([FromRoute(Name = "id")] int listId)
        {
            ShoppingList updatedList = _shoppingListService.GetById(listId);
            updatedList.OnShopping = true;
            _shoppingListService.Update(updatedList);
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(_shoppingListService.GetListWithProductsById(listId));
        }

        [HttpPost]
        public IActionResult EndShopping([FromForm] int listId)
        {
            ShoppingList clearList = _shoppingListService.GetById(listId);
            clearList.OnShopping = false;
            _shoppingListService.Update(clearList);
            _shoppingListService.Clear(clearList);
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View("~/Views/ShoppingList/Index.cshtml",
                _shoppingListService.GetListWithProductsById(listId));
        }
    }
}
