using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Bitirme_Proje.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bitirme_Proje.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IShoppingListService _shoppingListService;
        private IListProductService _listProductService;    
        public UserController(  IUserService userService, 
                                IShoppingListService shoppingListService,
                                IListProductService listProductService)
        {
            _userService = userService;
            _shoppingListService = shoppingListService;
            _listProductService = listProductService;
            
        }

        public IActionResult GetShoppingLists()
        {
            User user = _userService.GetByMail(HttpContext.Session.GetString("mail"));
            List<ShoppingList> shoppingLists = _shoppingListService.GetAllById(user.Id);
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(shoppingLists);
        }    
    }
}
