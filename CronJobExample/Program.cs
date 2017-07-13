using System;
using System.IO;

namespace CronJobExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var lipsums = File.ReadAllLines("./lipsum.txt");
            var random = new Random().Next(0, lipsums.Length - 1);
            Console.WriteLine($"lipusm text: {lipsums[random]}");
        }
    }
}
