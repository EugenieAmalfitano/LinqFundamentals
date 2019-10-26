using System;
using System.Collections.Generic;
using System.Linq;


namespace Features
{
    class Program
    {
        static readonly string Newline = "\n";
        static void Main(string[] args)
        {

            // Lambda with one parameter
            Func<int, int> square = x => x * x;

            Console.WriteLine($"The square of 3: {square(3)}{Newline}");

            // Lambda with two parameters
            Func<int, int, int> add = (x, y) => x + y;

            Console.WriteLine($"Add X + Y: {add(5, 6)}{Newline}");

            // Nested Lambda call
            Console.WriteLine($"The square of (5 + 6): {square(add(5, 6))}{Newline}");

            // Lambda can also include a method body with curly braces (less often used)
            Func<int, int, int> addTemp = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };

            Console.WriteLine($"Method body syntax for Add X + Y : {addTemp(3, 4)}{Newline}");

            // ARRAY of developers
            IEnumerable <Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name="Scott"},
                new Employee { Id = 2, Name="Chris"}
            };


            // LIST of sales employees
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 3, Name = "Alex"}
            };


            // Iterate through developers array
            Console.WriteLine("Developers Array using IEnumerable,  IEnumerator");
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            // Count() is one of the many extension methods in System.Linq.  
            Console.WriteLine($"Number of Developers: {developers.Count()}{Newline}");

            // Iterate through sales list
            Console.WriteLine("Sales List using IEnumerable,  IEnumerator");
            enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine($"Number of Sales Employees: {sales.Count()}{Newline}");

            // Use Lambda Expression to filter Developers whose name starts with S

            foreach (var employee in developers.Where(e => e.Name.StartsWith("S")))
            {
                Console.WriteLine($"Developers whose name starts with S: {Newline}{employee.Name}");
            }

        }
    }
}
