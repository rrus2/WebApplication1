using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrder(ProductViewModel model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == model.ProductID);
            throw new NotImplementedException();
        }

        public Task<Order> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}