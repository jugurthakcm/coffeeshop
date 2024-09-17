using Spectre.Console;

namespace coffeeshop;

public class ProductController
{
    internal static void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name:");
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

    internal static List<Product> ViewAllProducts()
    {
        using var db = new ProductsContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static void ViewProduct()
    {
        throw new NotImplementedException();
    }
}
