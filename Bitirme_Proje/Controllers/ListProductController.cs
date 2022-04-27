using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.EntityFramework.Entities;
using Bitirme_Proje.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Proje.Controllers
{
    public class ListProductController : Controller
    {
        private ListProduct listProduct;
        private IListProductService _listProductService;
        private IProductService _productService;
        private ICategoryService _categoryService;
        private ProductViewModel viewModel;

        public ListProductController(   ListProduct listProduct, 
                                        IListProductService listProductService,
                                        ProductViewModel viewModel,
                                        IProductService productService,
                                        ICategoryService categoryService)
        {
            this.listProduct = listProduct;
            _listProductService = listProductService;
            _productService = productService;
            _categoryService = categoryService;
            this.viewModel = viewModel;
        }

        [HttpPost]
        public IActionResult Update([FromForm] ProductViewModel viewModel)
        {
            listProduct.ProductId = viewModel.ProductId;
            listProduct.ShoppingListId = viewModel.ListId;
            listProduct.Description = viewModel.Description;

            _listProductService.Update(listProduct);
            return View("Detail", viewModel);
        }

        public IActionResult Detail([FromQuery] int listId, [FromQuery] int productId)
        {
            viewModel.ListId = listId;
            viewModel.ProductId = productId;
            viewModel.ProductName = _productService.GetById(productId).Name;
            viewModel.CategoryName = _categoryService.GetById(_productService.GetById(productId).CategoryId).Name;
            viewModel.Description = _listProductService.Get(listId, productId).Description;
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(viewModel);
        }

        public IActionResult Delete(int listId, int productId)
        {
            _listProductService.Delete(listId, productId);
            return RedirectToAction("Index", "ShoppingList", new { id = listId });
        }

        public IActionResult AllProducts([FromRoute] int id)
        {
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            ViewBag.ListId = id;
            ViewBag.Categories = _categoryService.GetAll();
            return View(_productService.GetProductsWithCategoryNotInList(id));
        }

        public IActionResult AddListProduct([FromQuery] int listId, int productId)
        {
            viewModel.ListId = listId;
            viewModel.ProductId = productId;
            viewModel.ProductName = _productService.GetById(productId).Name;
            viewModel.CategoryName = _categoryService.GetById(_productService.GetById(productId).CategoryId).Name;
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View(viewModel); ;
        }

        [HttpPost]
        public IActionResult AddListProduct([FromForm] ProductViewModel viewModel)
        {
            listProduct.ProductId = viewModel.ProductId;
            listProduct.ShoppingListId = viewModel.ListId;
            listProduct.Description = viewModel.Description;
            _listProductService.Add(listProduct);
            return RedirectToAction("AllProducts", new { id = viewModel.ListId });
        }

        [HttpPost]
        public IActionResult SearchProductsByName([FromForm] int listId, string searchText)
        {
            ViewBag.ListId = listId;
            ViewBag.SearchText = searchText;
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            ViewBag.Categories = _categoryService.GetAll();
            return View("AllProducts", _productService.SearchByName(listId, searchText));
        }

        [HttpPost]
        public IActionResult FilterByCategoryName([FromForm] int listId, string categoryName)
        {
            ViewBag.ListId = listId;
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.UserMail = HttpContext.Session.GetString("mail");
            return View("AllProducts", _productService.FilterByCategoryName(listId, categoryName));
        }
    }
}
