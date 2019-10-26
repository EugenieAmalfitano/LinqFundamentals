using System;
using System.Collections.Generic;
using System.Linq;


namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            // ARRAY of developers
            IEnumerable<Employee> developers = new Employee[]
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

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            // Count() is one of the many extension methods in System.Linq.  
            Console.WriteLine("Number of Developers: " + developers.Count() + "\n");

            // Iterate through sales list
            enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("Number of Sales Employees: " + sales.Count() + "\n");

            // Use Lambda Expression to filter Developers whose name starts with S
            Console.WriteLine("Developers whose name starts with S:\n");
            foreach (var employee in developers.Where(e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }

        }
    }
}
