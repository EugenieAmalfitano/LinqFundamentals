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
            IEnumerable<Employee> developer = new Employee[]
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

            IEnumerator<Employee> enumerator = developer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            // Count() is one of the many extension methods in System.Linq.  
            Console.WriteLine("Number of Developers: " + developer.Count() + "\n");

            // Iterate through sales list
            enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("Number of Sales Employees: " + sales.Count() + "\n");
        }
    }
}
