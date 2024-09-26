using Spectre.Console;
using static coffeeshop.Enums;

namespace coffeeshop;

internal static class UserInterface
{

    internal static void MainMenu(){
        var isAppRunning = true;

while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(
                MenuOptions.AddProduct,
                MenuOptions.DeleteProduct,
                MenuOptions.UpdateProduct,
                MenuOptions.ViewProduct,
                MenuOptions.ViewAllProducts
            )
    );

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductService.InsertProduct();
            break;

        case MenuOptions.DeleteProduct:
            ProductService.DeleteProduct();
            break;

        case MenuOptions.UpdateProduct:
            ProductService.UpdateProduct();
            break;

        case MenuOptions.ViewProduct:
            ProductService.GetProductById();
            break;

        case MenuOptions.ViewAllProducts:
            ProductService.GetAllProducts();
            break;
    }
}
    }
    internal static void ShowProduct(Product product)
    {
        var panel = new Panel(
            $@"Id: {product.Id}
Name: {product.Name}
Price: {product.Price}"
        );

        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }

    internal static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (var product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name, product.Price.ToString("C"));
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }
}
