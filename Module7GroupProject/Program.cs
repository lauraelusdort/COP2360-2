// Group Project: Programming Languages Dictionary
// Laura Elusdort and Franceska Francois 

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        /*Create a dictionary where each key is a category
        and each value is a list of programming languages in that category*/
        Dictionary<string, List<string>> programmingLanguages = new Dictionary<string, List<string>>();

        // This variable keeps the menu running until the user chooses to exit
        bool running = true;

        while (running)
        {
            //Display the menu options to the user
            Console.WriteLine("\n Programming Languages Dictionary:");

            // 1: Add the starter categories and languages to the dictionary
            Console.WriteLine("1. Populate Dictionary");

            // 2: Show all the categories and their associated programming languages
            Console.WriteLine("2. Display Dictionary");

            // 3: Remove an existing category from the dictionary
            Console.WriteLine("3. Remove a Category");

            // 4: Add a new category and language to the dictionary
            Console.WriteLine("4. Add New Category and Language");

            // 5: Add a new language to an existing category
            Console.WriteLine("5. Add Language to Existing Category");

            // 6: Sort the categories in the dictionary alphabetically and display them
            Console.WriteLine("6. Sort Categories");

            // Exit the program
            Console.WriteLine("7. Exit");

            // Prompt the user to enter a menu option
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine() ?? ""; // Read the user's input

            int choice; // This variable will store the converted number choice

            // Validate the user's input to ensure it's a number between 1 and 7
            if (!int.TryParse(input, out choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                continue; // Skip the rest of the loop and prompt again
            }

            // Use a switch statement to handle the user's menu choice
            switch (choice)
            {
                case 1:
                    // Call a method to populate the dictionary with starter categories and languages
                    PopulateDictionary(programmingLanguages);
                    break;
                case 2:
                    // Call a method to display all categories and their associated programming languages
                    DisplayDictionary(programmingLanguages);
                    break;
                case 3:
                    // Call a method to remove an existing category from the dictionary
                    RemoveCategory(programmingLanguages);
                    break;
                case 4:
                    // Call a method to add a new category and language to the dictionary
                    AddNewCategoryAndLanguage(programmingLanguages);
                    break;
                case 5:
                    // Call a method to add a new language to an existing category
                    AddLanguageToExistingCategory(programmingLanguages);
                    break;
                case 6:
                    // Call a method to sort the categories in the dictionary alphabetically and display them
                    SortCategories(programmingLanguages);
                    break;
                case 7:
                    // Set running to false to stop the loop and exit the program
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    // Runs if the user enters a number outside the valid range, which should not happen due to validation, but is included as a safety net
                    Console.WriteLine("An unexpected error occurred. Please try again.");
                    break;
            }
        }
    }

    // FUNCTION DEFINITIONS (Franceska will fill these in the methods below)

    // Adds starting categories and languages to the dictionary
    static void PopulateDictionary(Dictionary<string, List<string>> dict)
    {
        dict.Clear();

        dict["Frontend"] = new List<string> { "HTML", "CSS", "JavaScript" };
        dict["Backend"] = new List<string> { "C#", "Java", "Python" };
        dict["Mobile"] = new List<string> { "Swift", "Kotlin" };

        Console.WriteLine("Dictionary populated successfully!");
    }

    // Displays all categories and their associated programming languages
    static void DisplayDictionary(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("Dictionary is empty.");
            return;
        }

        foreach (var category in dict)
        {
            Console.WriteLine($"\n{category.Key}:");

            foreach (var lang in category.Value)
            {
                Console.WriteLine($" - {lang}");
            }
        }
    }

    // Removes an existing category from the dictionary
    static void RemoveCategory(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter category to remove: ");
        string category = Console.ReadLine() ?? "";

        if (dict.Remove(category))
        {
            Console.WriteLine("Category removed.");
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    // Adds a new category and language to the dictionary
    static void AddNewCategoryAndLanguage(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter new category: ");
        string category = Console.ReadLine() ?? "";

        if (dict.ContainsKey(category))
        {
            Console.WriteLine("Category already exists.");
            return;
        }

        Console.Write("Enter programming language: ");
        string language = Console.ReadLine() ?? "";

        dict[category] = new List<string> { language };

        Console.WriteLine("New category added.");
    }

    // Adds a new language to an existing category
    static void AddLanguageToExistingCategory(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter category: ");
        string category = Console.ReadLine() ?? "";

        if (!dict.ContainsKey(category))
        {
            Console.WriteLine("Category not found.");
            return;
        }

        Console.Write("Enter new language: ");
        string language = Console.ReadLine() ?? "";

        dict[category].Add(language);

        Console.WriteLine("Language added.");
    }

    // Sorts the categories in the dictionary alphabetically and displays them
    static void SortCategories(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("Dictionary is empty.");
            return;
        }

        var sorted = dict.Keys.OrderBy(k => k);

        foreach (var key in sorted)
        {
            Console.WriteLine(key);
        }
    }
}