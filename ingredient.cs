// The Ingredient class represents a single ingredient, with a name, calories, and food group
class Ingredient
{
    // Name of the ingredient
    public string Name { get; set; }

    // Calories of the ingredient
    public int Calories { get; set; }

    // Food group of the ingredient
    public string FoodGroup { get; set; }

    // Constructor for the Ingredient class
    public Ingredient(string name, int calories, string foodGroup)
    {
        Name = name;
        Calories = calories;
        FoodGroup = foodGroup;
    }
}

// Delegate for the CaloriesExceeded event
public delegate void CaloriesExceededEventHandler(Recipe recipe, CaloriesExceededEventArgs e);

// Event arguments for the CaloriesExceeded event
public class CaloriesExceededEventArgs : EventArgs
{
    // Total calories of the recipe
    public int TotalCalories { get; set; }

    // Constructor for the CaloriesExceededEventArgs class
    public CaloriesExceededEventArgs(int totalCalories)
    {
        TotalCalories = totalCalories;
    }
}