class Program
{
    static void Main(string[] args)
    {
        // Welcome the user to Recipe Manager
        Console.WriteLine("Welcome to Recipe Manager!");

        // List of recipes
        List<Recipe> recipes = new List<Recipe>();

        // Loop until the user chooses to exit
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a new recipe");
            Console.WriteLine("2. Display all recipes");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Create a new Recipe object and populate it with user input
                    Recipe recipe = new Recipe();
                    Console.Write("Enter the recipe name: ");
                    recipe.Name = Console.ReadLine();
                    recipe.GetIngredientsFromUser();
                    recipe.GetStepsFromUser();
                    recipes.Add(recipe);
                    break;
                case 2:
                    // Display all recipes to the user
                    if (recipes.Count == 0)
                    {
                        Console.WriteLine("No recipes added yet.");
                    }
                    else
                    {
                        recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
                        foreach (Recipe r in recipes)
                        {
                            Console.WriteLine(r.Name);
                        }
                        Console.Write("Enter the name of the recipe to display: ");
                        string recipeName = Console.ReadLine();
                        Recipe selectedRecipe = recipes.Find(r => r.Name == recipeName);
                        if (selectedRecipe != null)
                        {
                            selectedRecipe.DisplayRecipe();
                            selectedRecipe.CheckCalories();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                    }
                    break;
                case 3:
                    // Exit the application
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}