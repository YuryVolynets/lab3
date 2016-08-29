using System;
using System.IO;


namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string tocName = "toc.data", fileName = "file.data";

            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());

            Exec.Generate(tocName, fileName, n);

            Exec.Print(tocName, fileName, n);

            Console.Write("AgeMin: ");
            int ageMin = int.Parse(Console.ReadLine());
            Console.Write("AgeMax: ");
            int ageMax = int.Parse(Console.ReadLine());

            Exec.Search(tocName, fileName, n, ageMin, ageMax);
        }
    }
}
