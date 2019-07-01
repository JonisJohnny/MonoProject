using Autofac;
using Project.Repository;
using Project.Service;
using Project.Service.Common;

namespace Project.WebAPI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<DIModule>().As<IDIModule>();
            builder.RegisterType<CarsService>().As<ICarsService>();
            builder.RegisterType<InitilizeMap>().As<IInitilizeMap>();

            return builder.Build();
        }
    }
}
