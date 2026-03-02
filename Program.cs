using System;
using System.Linq.Expressions;
namespace Mod4Assignment
{
class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the first number:");
                string input1 = Console.ReadLine();

                Console.WriteLine("Enter the second number:");
                string input2 = Console.ReadLine();

                int result = Divide(input1, input2);
                Console.WriteLine("The result of dividing " + input1 + " by " + input2 + " is: " + result);
            }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero. Please enter a non-zero second number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number entered is too large or too small. Please enter a valid integer.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
            
        Console.ReadLine(); 

        }

        static int Divide(string str1, string str2)
        {
            int number1 = Convert.ToInt32(str1);
            int number2 = Convert.ToInt32(str2);
            return number1 / number2;
        }
    }
}