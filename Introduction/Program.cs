using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path); 
            ShowLargeFilesWithLinq(path);
        }
        private static void ShowLargeFilesWithoutLinq(string path)
        {
            Console.WriteLine("WITHOUT LINQ\n");
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
            Console.WriteLine("\n* * *\n\n");
        }
        private static void ShowLargeFilesWithLinq(string path)
        {
            Console.WriteLine("WITH LINQ\n");
            var query = new DirectoryInfo(path).GetFiles()
                       .OrderByDescending(f => f.Length)
                       .Take(5);
            foreach (var file in query)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
