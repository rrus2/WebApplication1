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
        public async Task<Order> CreateOrder(ProductViewModel model, string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == name);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == model.ProductID);
            var order = new Order { Product = product, ApplicationUser = user, Amount = model.Amount };
            product.Stock -= model.Amount;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            if (id <= 0)
                throw new Exception("ID cannot be 0 or less than");
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
            if (order == null)
                throw new Exception($"Order with ID: {id} does not exist");
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}