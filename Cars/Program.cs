﻿using System;
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
 
            // Use query syntax 
            var query =
                        from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined descending, car.Name ascending
                        select car;

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
