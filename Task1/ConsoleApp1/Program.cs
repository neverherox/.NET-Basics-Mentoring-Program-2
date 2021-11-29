using ClassLibrary1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = Console.ReadLine();
            Console.WriteLine(Class1.GetHello(userName));
        }
    }
}
