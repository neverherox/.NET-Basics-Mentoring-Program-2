using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintFirstChar("");
        }

        public static void PrintFirstChar(string line)
        {
            try
            {
                Console.WriteLine(line[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Empty string");
                throw;
            }
        }
    }
}