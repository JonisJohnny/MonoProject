using Project.DAL;
using Project.Model;
using Project.Model.Common;
using AutoMapper;

namespace Project.Repository
{
    public class InitilizeMap : IInitilizeMap
    {

        public void Load()
        {
            Mapper.Initialize(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<VehicleModelEntity, VehicleModel_Model>().ReverseMap();
                cfg.CreateMap<VehicleModelEntity, IVehicleModel_Model>().ReverseMap();
                cfg.CreateMap<IVehicleModel_Model, VehicleModel_Model>().ReverseMap();

                cfg.CreateMap<VehicleMakeEntity, VehicleMake_Model>().ReverseMap();
                cfg.CreateMap<VehicleMakeEntity, IVehicleMake_Model>().ReverseMap();
                cfg.CreateMap<IVehicleMake_Model, VehicleMake_Model>().ReverseMap();
            });

        }


    }
}