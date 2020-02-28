using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Client.Side
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Start();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder().ConfigureWebHostDefaults(configure =>
            {
                configure.UseStartup<Startup>();
            });
    }
}
