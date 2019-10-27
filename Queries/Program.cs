using System;
using System.Linq;
using System.Collections.Generic;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                 new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2019},
                 new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2006},
                 new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1943 },
                 new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1999 }
            };

            var query = movies.Where(m => m.Year > 2000);

            Console.WriteLine("Movies After the Year 2000");
            foreach (var movie in query)
            {
                Console.WriteLine($"Title: {movie.Title,-20}  Year: {movie.Year,4}");
            }

        }
    }
}
