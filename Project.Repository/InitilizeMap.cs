using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using AutoMapper;

namespace Project.Repository
{
    public class InitilizeMap : Profile
    {

        public InitilizeMap()
        {

                Mapper.Initialize(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<VehicleModelEntity, VehicleModelModels>().ReverseMap();
                cfg.CreateMap<VehicleModelEntity, IVehicleModelModels>().ReverseMap();
                cfg.CreateMap<IVehicleModelModels, VehicleModelModels>().ReverseMap();

                cfg.CreateMap<VehicleMakeEntity, VehicleMakeModels>().ReverseMap();
                cfg.CreateMap<VehicleMakeEntity, IVehicleMakeModels>().ReverseMap();
                cfg.CreateMap<IVehicleMakeModels, VehicleMakeModels>().ReverseMap();

                cfg.CreateMap<VehicleMakeArgs, VehicleMakeEntity>().ReverseMap();
                cfg.CreateMap<VehicleModelArgs, VehicleModelEntity>().ReverseMap();
                
            });

        }
        


    }
    
    

}