using System;
using System.Collections.Generic;

namespace ContractorProject
{
    // =========================
    // CONTRACTOR CLASS (DONE)
    // =========================
    public class Contractor
    { 
        private string contractorName;
        private int contractorNumber;
        private DateTime startDate;

        public Contractor(string name, int number, DateTime date)
        {
            contractorName = name;
            contractorNumber = number;
            startDate = date;
        }

        // Getters
        public string GetName() => contractorName;
        public int GetNumber() => contractorNumber;
        public DateTime GetStartDate() => startDate;

        // Setters
        public void SetName(string name) => contractorName = name;
        public void SetNumber(int number) => contractorNumber = number;
        public void SetStartDate(DateTime date) => startDate = date;
    }

    // =========================
    // SUBCONTRACTOR CLASS (DONE)
    // =========================
    public class Subcontractor : Contractor
    {
        private int shift; // 1 = Day, 2 = Night
        private double hourlyPayRate;

        public Subcontractor(string name, int number, DateTime date, int shift, double payRate)
            : base(name, number, date)
        {
            this.shift = shift;
            this.hourlyPayRate = payRate;
        }

        public int GetShift() => shift;
        public double GetPayRate() => hourlyPayRate;

        // Added by Laura: returns the shift name instead of only displaying 1 or 2
        public string GetShiftName()
        {
            if (shift == 1)
            {
                return "Day";
            }
            else
            {
                return "Night";
            }
        }

        // PAY CALCULATION (DONE)
        public float CalculatePay(float hoursWorked)
        {
            double pay = hourlyPayRate * hoursWorked;

            // Night shift bonus (3%)
            if (shift == 2)
            {
                pay *= 1.03;
            }

            return (float)pay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Subcontractor> workers = new List<Subcontractor>();

            Console.WriteLine("Enter number of subcontractors:");
            int count = GetValidInt();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nSubcontractor #{i + 1}");

                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Number: ");
                int number = GetValidInt();

                Console.Write("Start Date (yyyy-mm-dd): ");
                DateTime date = GetValidDate();

                Console.Write("Shift (1 = Day, 2 = Night): ");
                int shift = GetValidShift();

                Console.Write("Hourly Pay Rate: ");
                double rate = GetValidDouble();

                Subcontractor sc = new Subcontractor(name, number, date, shift, rate);
                workers.Add(sc);
            }

            Console.WriteLine("\n--- Payroll ---");

            foreach (var worker in workers)
            {
                Console.Write($"\nEnter hours worked for {worker.GetName()}: ");
                float hours = GetValidFloat();

                float pay = worker.CalculatePay(hours);

                Console.WriteLine("\nContractor Information");
                Console.WriteLine("----------------------");
                Console.WriteLine($"Name: {worker.GetName()}");
                Console.WriteLine($"Contractor Number: {worker.GetNumber()}");
                Console.WriteLine($"Start Date: {worker.GetStartDate():yyyy-MM-dd}");
                Console.WriteLine($"Shift: {worker.GetShiftName()}");
                Console.WriteLine($"Hourly Pay Rate: ${worker.GetPayRate():F2}");
                Console.WriteLine($"Hours Worked: {hours}");
                Console.WriteLine($"Total Pay: ${pay:F2}");
            }
        }

        // Added by Laura: input validation methods to prevent the program from crashing

        static int GetValidInt()
        {
            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a whole number: ");
            }

            return value;
        }

        static double GetValidDouble()
        {
            double value;

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            return value;
        }

        static float GetValidFloat()
        {
            float value;

            while (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            return value;
        }

        static DateTime GetValidDate()
        {
            DateTime date;

            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Invalid date. Please enter date as yyyy-mm-dd: ");
            }

            return date;
        }

        static int GetValidShift()
        {
            int shift;

            while (!int.TryParse(Console.ReadLine(), out shift) || (shift != 1 && shift != 2))
            {
                Console.Write("Invalid shift. Enter 1 for Day or 2 for Night: ");
            }

            return shift;
        }
    }
}
