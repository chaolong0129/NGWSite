using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGWSite.Models;

namespace NGWSite.Controllers {
    public class OrdersController : Controller {
        private readonly MyDbContext context;
        public OrdersController (MyDbContext context) {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetOrders () {
            var result = context.Orders.
                        Include(order => order.OrderItems).
                        ThenInclude(a => a.Product).
                        ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveOrders([FromBody] Order order)
        {
            context.Orders.Add(order);
            var result = context.SaveChanges();
            return Accepted(result);
        }
    }
}