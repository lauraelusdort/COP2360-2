using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Create dictionary
        Dictionary<string, List<string>> programmingLanguages = new Dictionary<string, List<string>>();

        bool running = true;

        while (running)
        {
            //Display menu
            Console.WriteLine("\n Programming Languages Dictionary:");
            Console.WriteLine("1. Populate the dictionary");
            Console.WriteLine("2. Display the dictionary");
            Console.WriteLine("3. Remove a key");
            Console.WriteLine("4. Add a new programming language");
            Console.WriteLine("5. Add value to an existing key");
            Console.WriteLine("6. Sort the keys in the dictionary");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
}
