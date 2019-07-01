
using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Project.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IDIModule>();
                app.ProcessData();
            }
                CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
