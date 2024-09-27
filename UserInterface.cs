using coffeeshop.Models;
using coffeeshop.Services;
using Spectre.Console;
using static coffeeshop.Enums;

namespace coffeeshop;

internal static class UserInterface
{

    internal static void MainMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                    MenuOptions.AddCategory,
                    MenuOptions.ViewAllCategories,
                    MenuOptions.DeleteCategory,
                    MenuOptions.UpdateCategory,
                        MenuOptions.AddProduct,
                        MenuOptions.DeleteProduct,
                        MenuOptions.UpdateProduct,
                        MenuOptions.ViewProduct,
                        MenuOptions.ViewAllProducts
                    )
            );

            switch (option)
            {
                case MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;

                case MenuOptions.ViewAllCategories:
                    CategoryService.GetAllCategories();
                    break;

                case MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;


                case MenuOptions.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;

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
            $@"Id: {product.ProductId}
Name: {product.Name}
Price: {product.Price.ToString("C")}
Category: {product.Category.Name}"
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
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(product.ProductId.ToString(), product.Name, product.Price.ToString("C"), product.Category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }


    internal static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");


        foreach (var category in categories)
        {
            table.AddRow(category.CategoryId.ToString(), category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }
}
