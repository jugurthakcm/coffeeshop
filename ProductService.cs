using Spectre.Console;

namespace coffeeshop;

internal class ProductService
{
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
