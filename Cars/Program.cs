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

            // ENUMERABLE ANY
            // Are there any cars in the dataset?
            var areThereCars = cars.Any();

            // Are there any Fords
            var areThereAnyFords = cars.Any(c => c.Manufacturer == "Ford");


            // ENUMERABLE ALL
            var areTheyAllFords = cars.All(c => c.Manufacturer == "Ford"); // Will return false since there are other manufacturers

            // Find 10 most fuel efficient cars
            // Note: data was downloaded to Pluralsight class from http://fueleconomy.gov
            // Use query syntax 
            var query =
                        from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined descending, car.Name ascending
                        select new //anonymous type
                        {
                            car.Manufacturer,
                            car.Name,
                            car.Combined
                        };

            Console.WriteLine($"{"MAKE",-20}{ "MODEL",-25} Combined MPG");
            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer,-20}{ car.Name,-25} {car.Combined }");
            }


            // Same as above, with Query Syntax
            var query2 =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);

            Console.WriteLine($"\n\nQuery Syntax\n{"MAKE",-20}{ "MODEL",-25} Combined MPG");
            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer,-20}{ car.Name,-25} {car.Combined }");
            }

            // Find the top fuel-efficient car
            var top =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First();
            Console.WriteLine($"\n\nSingle most fuel-efficient BMW from 2016\n{"MAKE",-20}{ "MODEL",-25} Combined MPG");
            Console.WriteLine($"{top.Manufacturer,-20}{ top.Name,-25} {top.Combined }");

            // Alternate method: Find the top fuel-efficient car
            var top2 =
                cars
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First(c => c.Manufacturer == "BMW" && c.Year == 2016);
            Console.WriteLine($"\n\nAlternate method\n{"MAKE",-20}{ "MODEL",-25} Combined MPG");
            Console.WriteLine($"{top2.Manufacturer,-20}{ top2.Name,-25} {top2.Combined }");
        }

        private static List<Car> ProcessFile(string path)
        {
            // Using projection operation to parse the car from the CSV file
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1) // filter out empty lines
                    .ToCar();
            return query.ToList();
        }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
