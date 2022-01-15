using System;
using PluginBase;
using Reflection.Components;
using Reflection.CustomAttributes;
using Reflection.Services;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new ProvidersLoader();
            var factory = new ProvidersFactory(loader);

            var appSettings = new AppSettings(factory);
            var file = new File(factory);

            WriteConfig(appSettings);
            ReadConfig(appSettings);
            Console.WriteLine();
            WriteConfig(file);
            ReadConfig(file);
        }

        public static void WriteConfig(ConfigurationComponentBase config)
        {
            config.RetryCount = 3;
            config.Timeout = TimeSpan.FromSeconds(60);
            config.ConnectionString = "connection";
            config.RelativeError = null;
        }

        public static void ReadConfig(ConfigurationComponentBase config)
        {
            var connectionString = config.ConnectionString;
            var retryCount = config.RetryCount;
            var timeout = config.Timeout;
            var relativeError = config.RelativeError;

            Console.WriteLine($"{nameof(config.ConnectionString)}: {connectionString}");
            Console.WriteLine($"{nameof(config.RetryCount)}: {retryCount}");
            Console.WriteLine($"{nameof(config.Timeout)}: {timeout}");
            Console.WriteLine($"{nameof(config.RelativeError)}: {relativeError}");
        }
    }
}
