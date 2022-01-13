using System;
using Reflection.Components;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new AppSettings();

            file.RetryCount = null;
            file.Timeout = TimeSpan.FromSeconds(300);
            file.ConnectionString = "300";

            var connectionString = file.ConnectionString;
            var retryCount = file.RetryCount;
            var timeout = file.Timeout;

            

            Console.WriteLine(connectionString);
            Console.WriteLine(retryCount);
            Console.WriteLine(timeout);
        }
    }
}
