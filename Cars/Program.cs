using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            // Find 10 most fuel efficient cars
            // Note: data was downloaded to Pluralsight class from http://fueleconomy.gov

            var query  = cars.OrderByDescending(c => c.Combined) // Combined fuel efficiency
                             .ThenBy(c => c.Name);               // .ThenBy: secondary alpha sort when MPG is tied
            Console.WriteLine($"{ "MODEL",-25} Combined MPG");
            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{ car.Name,-25} {car.Combined }");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            //return
            //    File.ReadAllLines(path)
            //        .Skip(1)
            //        .Where(line => line.Length > 1)
            //        .Select(Car.ParseFromCsv)
            //        .ToList();


            // Use query syntax instead
            var query =
                from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Car.ParseFromCsv(line);

            return query.ToList();
        }
    }
}
