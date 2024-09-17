using Spectre.Console;

namespace coffeeshop;

internal class ProductService
{
    internal static void InsertProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name:");
        ProductController.AddProduct(name);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    internal static void GetAllProducts()
    {
        var products = ProductController.GetAllProducts();
        UserInterface.ShowProductTable(products);
    }

    internal static void GetProductById()
    {
        var product = ProductService.GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    // Get User Product Input

    internal static Product GetProductOptionInput()
    {
        var products = ProductController.GetAllProducts();

        var productsArray = products.Select(p => p.Name).ToArray();

        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Choose Product").AddChoices(productsArray)
        );

        var id = products.Single(p => p.Name == option).Id;

        var product = ProductController.GetProductById(id);

        return product;
    }
}
