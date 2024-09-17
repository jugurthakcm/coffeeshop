using coffeeshop;
using Spectre.Console;

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

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}
