using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        int _year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returning {_year,4} for {Title,-20}");
                return _year;
            }
            set
            {
                _year = value;
            }
        }
    }
}
