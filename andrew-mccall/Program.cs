using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace andrew_mccall
{

    public class Program
    {

        public static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["API_MASTER_KEY"])){
                throw new Exception("Missing App.config, Should have Key API_MASTER_KEY");
            }
            
            if (ConfigurationManager.AppSettings["API_MASTER_KEY"] == "Example"){
                Console.Error.WriteLine("WARNING:");
                WarningException warning = new WarningException("Default API_MASTER_KEY, Go to App.config to change");
                Console.Error.WriteLine(warning);
                Console.Error.WriteLine();
            }
            
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
