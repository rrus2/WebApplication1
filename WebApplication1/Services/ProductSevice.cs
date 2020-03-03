using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class ProductSevice : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductSevice(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(ProductViewModel model, HttpPostedFileBase file)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                GenreID = model.GenreID
            };
            if (file != null)
            {
                var test = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
                var path = HttpContext.Current.Server.MapPath("~/Content/Images/");
                var filename =  Guid.NewGuid().ToString() + file.FileName;
                file.SaveAs(path + filename);
                product.ImagePath = test + "/Content/Images/" + filename;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            if (product == null)
                throw new Exception("Product with id: {id} not found");
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}