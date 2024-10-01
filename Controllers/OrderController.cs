using coffeeshop.Models;

namespace coffeeshop.Controllers
{
    internal class OrderController
    {
        internal static void AddOrder(List<OrderProduct> order)
        {
            using var db = new ProductsContext();

            db.OrderProducts.AddRange(order);

            db.SaveChanges();
        }
    }
}
