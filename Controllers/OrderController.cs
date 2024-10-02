using coffeeshop.Models;
using Microsoft.EntityFrameworkCore;

namespace coffeeshop.Controllers;

internal class OrderController
{
    internal static void AddOrder(List<OrderProduct> order)
    {
        using var db = new ProductsContext();

        db.OrderProducts.AddRange(order);

        db.SaveChanges();
    }

    internal static List<Order> GetOrders()
    {
        using var db = new ProductsContext();
        var ordersList = db.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).ThenInclude(p => p.Category).ToList();

        return ordersList;

    }

    
}

