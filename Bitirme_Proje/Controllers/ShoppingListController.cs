using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Proje.Controllers
{
    public class ShoppingListController : Controller
    {
        private IShoppingListService _shoppingListService;
        private IUserService _userService;
        public ShoppingListController(IShoppingListService shoppingListService, IUserService userService)
        {
            _shoppingListService = shoppingListService;
            _userService = userService;
        }
        public IActionResult Index([FromRoute] int id)
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(_shoppingListService.GetListWithProductsById(id));
        }

        public IActionResult Add()
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View();
        }

        [HttpPost]
        public IActionResult Add(ShoppingList shoppingList)
        {
            shoppingList.UserId = _userService.GetByMail(HttpContext.Session.GetString("mail")).Id;
            shoppingList.OnShopping = false;
            _shoppingListService.Add(shoppingList);
            return RedirectToAction();
        }

        public IActionResult Delete([FromQuery] int listId)
        {
            _shoppingListService.Delete(_shoppingListService.GetById(listId));
            return RedirectToAction("GetShoppingLists", "User");
        }
    }
}
