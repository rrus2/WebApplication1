using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IGenreService _genreService;
        private readonly IOrderService _orderService;
        public ProductsController(IProductService productService, IGenreService genreService, IOrderService orderService)
        {
            _productService = productService;
            _genreService = genreService;
            _orderService = orderService;
        }
        // GET: Products
        public async Task<ActionResult> IndexAsync()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        public async Task<ActionResult> Create()
        {
            await LoadGenres();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel model)
        {
            var file = HttpContext.Request.Files[0];
            if (!ModelState.IsValid)
            {
                await LoadGenres();
                return View(model);
            }

            await _productService.CreateProduct(model, file);
            return View("ThankYouCreateProduct", model);
        }
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productService.GetProduct(id);
            LoadAmount(product.Stock);
            ProductViewModel model = await CastToViewModel(product);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Buy(ProductViewModel model)
        {
            var name = HttpContext.User.Identity.Name;
            await _orderService.CreateOrder(model, name);
            return View("ThankYouBuyProduct", model);
        }

        private async Task<ProductViewModel> CastToViewModel(Product product)
        {
            var model = new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ImagePath = product.ImagePath,
                GenreID = product.GenreID,
            };
            model.Genre = await _genreService.GetGenre(product.GenreID);

            return model;
        }

        public ActionResult ThankYouCreateProduct()
        {
            return View();
        }
        public ActionResult ThankYouBuyProduct(ProductViewModel model)
        {
            return View(model);
        }
        private async Task LoadGenres()
        {
            var genres = await _genreService.GetGenres();
            var list = new SelectList(genres, "GenreID", "Name");
            ViewBag.Genres = list;
        }
        private void LoadAmount(int stock)
        {
            var amount = new List<int>();
            for (int i = 1; i < stock + 1; i++)
            {
                amount.Add(i);
            }
            ViewBag.Amount = new SelectList(amount);
        }
    }
}