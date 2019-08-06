using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Project.Repository;

namespace Project.WebAPI
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
    
            CreateWebHostBuilder(args).Build().Run();
 
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
