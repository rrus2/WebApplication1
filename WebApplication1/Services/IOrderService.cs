using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(ProductViewModel model, string name);
        Task<Order> DeleteOrder(int id);
    }
}
