using Autofac;
using Project.Repository.Common;
using AutoMapper;

namespace Project.Repository
{
  public class RepositoryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
      builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
    }
  }
}


