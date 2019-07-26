using Autofac;
using Project.Service.Common;
using AutoMapper;

namespace Project.Service
{
  public class ServiceModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
    }
  }
}


