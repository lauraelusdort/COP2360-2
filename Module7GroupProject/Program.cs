using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> programmingLanguages = new Dictionary<string, List<string>>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Programming Languages Dictionary ===");
            Console.WriteLine("1. Populate Dictionary");
            Console.WriteLine("2. Display Dictionary");
            Console.WriteLine("3. Remove a Category");
            Console.WriteLine("4. Add New Category and Language");
            Console.WriteLine("5. Add Language to Existing Category");
            Console.WriteLine("6. Sort Categories");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 7)
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    PopulateDictionary(programmingLanguages);
                    break;
                case 2:
                    DisplayDictionary(programmingLanguages);
                    break;
                case 3:
                    RemoveCategory(programmingLanguages);
                    break;
                case 4:
                    AddNewCategoryAndLanguage(programmingLanguages);
                    break;
                case 5:
                    AddLanguageToExistingCategory(programmingLanguages);
                    break;
                case 6:
                    SortCategories(programmingLanguages);
                    break;
                case 7:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }

    static void PopulateDictionary(Dictionary<string, List<string>> dict)
    {
        dict.Clear();

        dict["Frontend"] = new List<string> { "HTML", "CSS", "JavaScript" };
        dict["Backend"] = new List<string> { "C#", "Java", "Python" };
        dict["Mobile"] = new List<string> { "Swift", "Kotlin" };

        Console.WriteLine("Dictionary populated successfully!");
    }

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

    static void SortCategories(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("Dictionary is empty.");
            return;
        }

        var sorted = dict.Keys.OrderBy(k => k);

        Console.WriteLine("\nSorted Categories:");
        foreach (var key in sorted)
        {
            Console.WriteLine(key);
        }
    }
}