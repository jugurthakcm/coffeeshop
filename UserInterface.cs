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
                new SelectionPrompt<MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                    MainMenuOptions.ManageCategories,
                    MainMenuOptions.ManageProducts,
                    MainMenuOptions.ManageOrders,
                    MainMenuOptions.Quit
                    )
            );

            switch (option)
            {
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;

                case MainMenuOptions.ManageProducts:
                    ProductsMenu();
                    break;

                case MainMenuOptions.ManageOrders:
                    OrdersMenu();
                    break;

                case MainMenuOptions.Quit:
                    Console.WriteLine("Goodbye");
                    isAppRunning = false;
                    break;
            }
        }
    }

    internal static void CategoriesMenu()
    {
        var isCategoryMenuRunning = true;

        while (isCategoryMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                    CategoryMenu.AddCategory,
                    CategoryMenu.ViewAllCategories,
                    CategoryMenu.ViewCategory,
                    CategoryMenu.DeleteCategory,
                    CategoryMenu.UpdateCategory,
                    CategoryMenu.GoBack
                    )
            );

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;

                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetAllCategories();
                    break;

                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;

                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;


                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;

                case CategoryMenu.GoBack:
                    isCategoryMenuRunning = false;
                    break;

            }
        }
    }


    internal static void ProductsMenu()
    {
        var isProductMenuRunning = true;

        while (isProductMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ProductMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        ProductMenu.AddProduct,
                        ProductMenu.DeleteProduct,
                        ProductMenu.UpdateProduct,
                        ProductMenu.ViewProduct,
                        ProductMenu.ViewAllProducts,
                        ProductMenu.GoBack
                    )
            );

            switch (option)
            {
                 case ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;

                case ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;

                case ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;

                case ProductMenu.ViewProduct:
                    ProductService.GetProductById();
                    break;

                case ProductMenu.ViewAllProducts:
                    ProductService.GetAllProducts();
                    break;

                case ProductMenu.GoBack:
                    isProductMenuRunning = false;
                    break;
            }
        }
    }

    internal static void OrdersMenu()
    {
        var isOrderMenuRunning = true;

        while (isOrderMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<OrderMenu>()
                    .Title("Orders Menu")
                    .AddChoices(
                        OrderMenu.AddOrder,
                        OrderMenu.GoBack
                    )
            );

            switch (option)
            {
                case OrderMenu.AddOrder:
                    OrderService.InsertOrder();
                    break;

                case OrderMenu.GoBack:
                    isOrderMenuRunning = false;
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

    internal static void ShowCategory(Category category)
    {
        var panel = new Panel(
            $@"Id: {category.CategoryId}
Name: {category.Name}
Product Count: {category.Products.Count}"
        );

        panel.Header = new PanelHeader("Category Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

    }
}
