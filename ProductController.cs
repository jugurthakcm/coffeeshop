using Spectre.Console;

namespace coffeeshop;

public class ProductController
{
    internal static void AddProduct(string name)
    {
       
        using var db = new ProductsContext();

        db.Add(new Product { Name = name });
        db.SaveChanges();
    }

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    internal static List<Product> GetAllProducts()
    {
        using var db = new ProductsContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductsContext();

        var product = db.Products.SingleOrDefault(p => p.Id == id);

        return product;
    }
}
