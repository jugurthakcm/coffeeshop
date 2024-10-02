using coffeeshop.Models;
using Microsoft.EntityFrameworkCore;

namespace coffeeshop.Controllers;

public class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Add(product);
        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Remove(product);

        db.SaveChanges();
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Update(product);

        db.SaveChanges();
    }

    internal static List<Product> GetAllProducts()
    {
        using var db = new ProductsContext();

        var products = db.Products.Include(x => x.Category).ToList();

        return products;
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductsContext();

        var product = db.Products.Include(x => x.Category).SingleOrDefault(p => p.ProductId == id);

        return product;
    }
}
