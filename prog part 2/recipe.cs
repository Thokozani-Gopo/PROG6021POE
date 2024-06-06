using System;
using System.Collections.Generic;

// The Recipe class represents a single recipe, with a name, list of ingredients, and steps
class Recipe
{
    // Name of the recipe
    public string Name { get; set; }

    // List of ingredients for the recipe
    public List<Ingredient> Ingredients { get; set; }

    // List of steps for the recipe
    public List<string> Steps { get; set; }

    // Constructor for the Recipe class
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    // Method to prompt the user for ingredients and add them to the Ingredients list
    public void GetIngredientsFromUser()
    {
        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write($"enter ingredient {i + 1} name: ");
            string name = Console.ReadLine();
            Console.Write($"enter ingredient {i + 1} calories: ");
            int calories = int.Parse(Console.ReadLine());
            Console.Write($"Enter ingredient {i + 1} food group: ");
            string foodGroup = Console.ReadLine();
            Ingredients.Add(new Ingredient(name, calories, foodGroup));
        }
    }

    // Method to prompt the user for steps and add them to the Steps list
    public void GetStepsFromUser()
    {
        Console.Write("Enter the number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());

        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            string step = Console.ReadLine();
            Steps.Add(step);
        }
    }

    // Method to display the recipe to the user
    public void DisplayRecipe()
    {
        Console.WriteLine($"\nRecipe: {Name}");
        Console.WriteLine("Ingredients:");
        foreach (Ingredient ingredient in Ingredients)
        {
            Console.WriteLine($"- {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup} group)");
        }
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + Steps[i]);
        }
    }

    // Method to calculate the total calories of the recipe
    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (Ingredient ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    // Event to notify when the total calories exceed 300
    public event CaloriesExceededEventHandler CaloriesExceeded;

    // Method to check if the total calories exceed 300 and raise the event if so
    public void CheckCalories()
    {
        int totalCalories = CalculateTotalCalories();
        if (totalCalories > 300)
        {
            CaloriesExceeded?.Invoke(this, new CaloriesExceededEventArgs(totalCalories));
        }
    }
}



