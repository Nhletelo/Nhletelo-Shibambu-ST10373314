using System;
using System.Text.RegularExpressions;


namespace RecipeProgram
{
    // Create a class to stand in for an ingredient.
    public class Ingredient
    {
        // Characteristics to record an ingredient's name, amount, starting amount, and unit
        public string Name { get; set; }// The ingredient's name is stored in this attribute.
        public double InitialQuantity { get; set; } // The ingredient's initial quantity is stored in this attribute.
        public double Quantity { get; set; } // The ingredient's quantity is stored in this attribute.

        public string Unit { get; set; } // // The ingredient's measurement unit is stored in this property.

        // Use the constructor to initialize an ingredient with a name, quantity, and unit.
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name; //The name property should be initialized using the specified name.
            Quantity = quantity; // Set the quantity property's initial value to the given amount.
            InitialQuantity = quantity; // Use the supplied quantity to initialize the initial quantity property.
            Unit = unit; // Set the unit property's initial value to the supplied unit.
        }

        // Modify the ToString function to show a component in a legible manner
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}"; // Provide back the ingredient as a string in the format "quantity unit of name".
        }
    }

    // Creating a class that represents a recipe.

    class Recipe
    {
        // Properties to store the name, ingredients, and steps of a recipe
        public string Name { get; set; } // This property holds the name of the recipe.
        public Ingredient[] Ingredients { get; set; } // This property holds an array of ingredients for the recipe.
        public string[] Steps { get; set; } // This property holds an array of steps for the recipe.

        // Constructor to initialize a recipe with a name, number of ingredients, and number of steps
        public Recipe(string name, int ingredientCount, int stepCount)
        {
            Name = name; // Initialize the name property with the provided name.
            Ingredients = new Ingredient[ingredientCount]; // Create a new array of ingredients with the provided ingredient count.
            Steps = new string[stepCount]; // Create a new array of steps with the provided step count.
        }

        // Method to add an ingredient to the recipe at a specific index
        public void AddIngredient(int index, Ingredient ingredient)
        {
            Ingredients[index] = ingredient; // Add the provided ingredient to the ingredients array at the specified index.
        }

        // Method to add a step to the recipe at a specific index
        public void AddStep(int index, string step)
        {
            Steps[index] = step; // Add the provided step to the steps array at the specified index.
        }

        // Way to present the recipe to the user
        public void DisplayRecipe()
        {
            // Show the name of the recipe
            Console.WriteLine($"**Recipe: {Name}**");

            // Show the list of ingredients
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}"); // Use the format "quantity unit of name" to display each ingredient.

            }

            // Display the list of steps
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}"); // Show the number that corresponds to each step.
            }
        }

        // How to scale the recipe according to a specified factor

        public void ScaleRecipe(double factor)
        {
            // Verify the validity of the factor
            if (factor <= 0)
            {
                Console.WriteLine("Invalid scaling factor. Please enter a positive number.");
                return;
            }

            // Adjust each ingredient's quantity by the scaling factor.
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor; // Adjust each ingredient's amount based on the given factor.
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }

        // A procedure to return all ingredient quantities to their initial, non-negative values
        public void ResetQuantities()
        {
            // Verify that the quantity of each ingredient is non-negative.
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = Math.Max(ingredient.InitialQuantity, 0); // Ensure that the quantity of each ingredient is non-negative.
            }
            Console.WriteLine("Ingredient quantities reset to their original non-negative values.");
        }
    }

    // Main program class
    class Program
    {
        // A list of permitted units that is predefined and includes shortcuts and complete names

        static string[] allowedUnits = { "grams", "g", "kilograms", "kg", "ounces", "oz", "cups", "cup", "liters", "L", "teaspoons", "tsp", "tablespoons", "tbsp", "tablespoon" };

        //  The Main method
        static void Main(string[] args)
        {
            Recipe recipe = null; // Set a variable's initial value to the current recipe.

            // Show the welcome message
            Console.WriteLine("\nWelcome to our Recipe App!");

            // Repeat to show the menu and process user input
            while (true)
            {
                // Display the menu items.

                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create Recipe");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                // Check the user's choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    continue;
                }

                // Take actions in accordance with the user's selection
                switch (choice)
                {
                    case 1: // Develop a new recipe
                        recipe = CreateRecipe();
                        break;
                    case 2: // Show the current recipe.
                        if (recipe == null)
                        {
                            Console.WriteLine("No recipe created yet.");
                        }
                        else
                        {
                            recipe.DisplayRecipe();
                        }
                        break;
                    case 3: // Scale the existing recipe.
                        if (recipe == null)
                        {
                            Console.WriteLine("No recipe to scale.");
                        }
                        else
                        {
                            double factor;
                            Console.Write("Enter scaling factor: ");
                            if (!double.TryParse(Console.ReadLine(), out factor))
                            {
                                Console.WriteLine("Invalid scaling factor. Please enter a valid number.");
                                continue;
                            }
                            recipe.ScaleRecipe(factor);
                        }
                        break;
                    case 4: // Adjust the ingredient quantities.
                        if (recipe == null)
                        {
                            Console.WriteLine("No recipe to reset quantities.");
                        }
                        else
                        {
                            recipe.ResetQuantities();
                            Console.WriteLine("Ingredient quantities reset.");
                        }
                        break;
                    case 5: // Delete the active recipe.
                        if (recipe == null)
                        {
                            Console.WriteLine("No recipe to clear.");
                        }
                        else
                        {
                            recipe = null;
                            Console.WriteLine("Recipe cleared.");
                        }
                        break;
                    case 6: // Close the application
                        Console.WriteLine("Goodbye!");
                        return;
                    default: // Deal with incorrect selections
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        // Procedure for making a new recipe
        static Recipe CreateRecipe()
        {
            // Request information from the user for the new recipe.
            string name;
            do
            {
                Console.Write("Enter recipe name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Recipe name cannot be empty. Please enter a valid name.");
                }
                else if (ContainsNumbers(name))
                {
                    Console.WriteLine("Invalid recipe name. Please enter a valid name containing only letters.");
                    name = null; // Resetting the name to null will repeat the loop.
                }

            } while (string.IsNullOrWhiteSpace(name));

            // Examine and confirm the ingredient count.
            int ingredientCount;
            do
            {
                Console.Write("Enter number of ingredients: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Number of ingredients cannot be empty. Please enter a valid positive integer.");
                    continue;
                }

                if (!int.TryParse(input, out ingredientCount) || ingredientCount <= 0)
                {
                    Console.WriteLine("Invalid number of ingredients. Please enter a valid positive integer.");
                    continue;
                }

                break; // If the input is valid, end the loop.
            } while (true);

            // Only move forward if the ingredient count is accurate.
            if (ingredientCount <= 0)
            {
                return null;
            }

            //Examine and confirm how many steps there are.
            int stepCount;
            do
            {
                Console.Write("Enter number of steps: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Number of steps cannot be empty. Please enter a valid positive integer.");
                    continue;
                }

                if (!int.TryParse(input, out stepCount) || stepCount <= 0)
                {
                    Console.WriteLine("Invalid number of steps. Please enter a valid positive integer.");
                    continue;
                }

                break; // If the input is correct, end the loop.
            } while (true);

            // Construct a new recipe object using the supplied information.

            Recipe recipe = new Recipe(name, ingredientCount, stepCount);

            // Request information from the user for every ingredient.

            for (int i = 0; i < ingredientCount; i++)
            {
                string ingredientName;
                do
                {
                    Console.Write($"Enter name of ingredient {i + 1}: ");
                    ingredientName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingredientName) || double.TryParse(ingredientName, out _))
                    {
                        Console.WriteLine("Invalid ingredient name. Please enter a valid name.");
                    }
                    else
                    {
                        break; // End the loop in the event that the input is valid
                    }
                } while (true);

                double quantity;
                bool validQuantity = false;
                do
                {
                    Console.Write($"Enter quantity of {ingredientName}: ");
                    string quantityInput = Console.ReadLine();

                    if (!double.TryParse(quantityInput, out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid positive number.");
                    }
                    else
                    {
                        validQuantity = true;
                    }
                } while (!validQuantity);

                string unit;
                bool validUnit = false;
                do
                {
                    Console.Write($"Enter unit of {ingredientName}: ");
                    unit = Console.ReadLine();

                    // Verify that the unit you typed is in the list of permitted units.
                    if (!IsUnitAllowed(unit))
                    {
                        Console.WriteLine("Invalid unit. Please enter one of the following units: grams, kilograms, ounces, cups, liters, teaspoons, tablespoons");
                    }
                    else
                    {
                        validUnit = true;
                    }
                } while (!validUnit);

                // Using the provided information, create a new ingredient object and add it to the recipe.
                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit);
                recipe.AddIngredient(i, ingredient);
            }

            // Request information from the user for each step.
            for (int i = 0; i < stepCount; i++)
            {
                string step;
                do
                {
                    Console.Write($"Enter step {i + 1}: ");
                    step = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(step))
                    {
                        Console.WriteLine("Step cannot be empty. Please enter a valid step.");
                    }
                } while (string.IsNullOrWhiteSpace(step)); // Keep asking until a step that isn't empty is entered.

                recipe.AddStep(i, step);
            }

            // Show a message of success and give back the generated recipe.
            Console.WriteLine("Recipe created successfully.");
            return recipe;
        }

        // Procedure to determine if a unit is permitted
        static bool IsUnitAllowed(string unit)
        {
            foreach (string allowedUnit in allowedUnits)
            {
                if (string.Equals(unit, allowedUnit, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // A way to determine whether a string has numbers in it
        static bool ContainsNumbers(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }
    }
}

