using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dictionary storing keys and multiple values
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n==== DICTIONARY MENU ====");
            Console.WriteLine("1. Populate Dictionary");
            Console.WriteLine("2. Display Dictionary");
            Console.WriteLine("3. Remove a Key");
            Console.WriteLine("4. Add New Key & Value");
            Console.WriteLine("5. Add Value to Existing Key");
            Console.WriteLine("6. Sort Keys");
            Console.WriteLine("7. Exit");

            Console.Write("Enter choice: ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Populate(dictionary);
                    break;

                case 2:
                    Display(dictionary);
                    break;

                case 3:
                    RemoveKey(dictionary);
                    break;

                case 4:
                    AddNewKey(dictionary);
                    break;

                case 5:
                    AddValue(dictionary);
                    break;

                case 6:
                    SortKeys(dictionary);
                    break;

                case 7:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // a. Populate dictionary with sample data
    static void Populate(Dictionary<string, List<string>> dict)
    {
        dict["Students"] = new List<string> { "John", "Maria", "Alex" };
        dict["Courses"] = new List<string> { "Math", "Science", "IT" };
        dict["Languages"] = new List<string> { "C#", "Java", "Python" };

        Console.WriteLine("Dictionary populated successfully.");
    }

    // b. Display dictionary using foreach enumeration
    static void Display(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("Dictionary is empty.");
            return;
        }

        Console.WriteLine("\n--- Dictionary Contents ---");

        foreach (var pair in dict)
        {
            Console.Write(pair.Key + ": ");

            foreach (var value in pair.Value)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }

    // c. Remove a key
    static void RemoveKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter key to remove: ");
        string key = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("Invalid key.");
            return;
        }

        if (dict.Remove(key))
            Console.WriteLine("Key removed successfully.");
        else
            Console.WriteLine("Key not found.");
    }

    // d. Add new key and value
    static void AddNewKey(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter new key: ");
        string key = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("Invalid key.");
            return;
        }

        if (dict.ContainsKey(key))
        {
            Console.WriteLine("Key already exists.");
            return;
        }

        Console.Write("Enter value: ");
        string value = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine("Invalid value.");
            return;
        }

        dict[key] = new List<string> { value };

        Console.WriteLine("New key and value added successfully.");
    }

    // e. Add value to existing key
    static void AddValue(Dictionary<string, List<string>> dict)
    {
        Console.Write("Enter existing key: ");
        string key = Console.ReadLine() ?? "";

        if (!dict.ContainsKey(key))
        {
            Console.WriteLine("Key not found.");
            return;
        }

        Console.Write("Enter value to add: ");
        string value = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine("Invalid value.");
            return;
        }

        dict[key].Add(value);

        Console.WriteLine("Value added successfully.");
    }

    // f. Sort keys
    static void SortKeys(Dictionary<string, List<string>> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("Dictionary is empty.");
            return;
        }

        List<string> keys = new List<string>(dict.Keys);
        keys.Sort();

        Console.WriteLine("\n--- Sorted Keys ---");

        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }
    }
}
