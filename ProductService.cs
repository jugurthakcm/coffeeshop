using Spectre.Console;

namespace coffeeshop;

internal class ProductService
{
    internal static void InsertProduct()
    {
        Product product =
            new()
            {
                Name = AnsiConsole.Ask<string>("Product's name:"),
                Price = AnsiConsole.Ask<decimal>("Product's price:")
            };
        ProductController.AddProduct(product);
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
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Product's new name:")
            : product.Name;
        product.Price = AnsiConsole.Confirm("Update price?")
            ? AnsiConsole.Ask<decimal>("Product's new price:")
            : product.Price;

        ProductController.UpdateProduct(product);
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
