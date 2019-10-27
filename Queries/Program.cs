﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static string Newline = "\n";
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                 new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008},
                 new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010},
                 new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
                 new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
            };

            var query = movies.Filter(m => m.Year > 2000).ToList();

            // Count() does not offer deferred excution: 
            //   it forces the query to execute immediately
            //   this results in duplication of work
            Console.WriteLine($"Numer of rows returned by query: {query.Count()}{Newline}"); 

            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}
