using coffeeshop.Controllers;
using coffeeshop.Models;
using Spectre.Console;

namespace coffeeshop.Services
{
    internal class CategoryService
    {
        internal static void InsertCategory()
        {
            var category = new Category();
            category.Name = AnsiConsole.Ask<string>("Category's name:");

            CategoryController.AddCategory(category);
        }

        internal static void GetAllCategories()
        {
            var categories = CategoryController.GetCategories();
            UserInterface.ShowCategoryTable(categories);
        }

        internal static void GetCategory()
        {
            var category = GetCategoryOptionInput();
            UserInterface.ShowCategory(category);
        }

        internal static void DeleteCategory()
        {
            var category = GetCategoryOptionInput();
           CategoryController.DeleteCategory(new Category { CategoryId = category.CategoryId });
        }


        internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

            category.Name = AnsiConsole.Confirm("Update name?")
                ? AnsiConsole.Ask<string>("Category's new name:") : category.Name;
         

        CategoryController.UpdateCategory(category);
    }

       
        internal static Category GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();

            var categoriesArray = categories.Select(c => c.Name).ToArray();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("Choose Category").AddChoices(categoriesArray)
            );

            var category = categories.Single(c => c.Name == option);

            return category;
        }
    }
}
