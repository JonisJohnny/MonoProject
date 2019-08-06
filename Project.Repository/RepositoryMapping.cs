using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using AutoMapper;

namespace Project.Repository
{
    public class RepositoryMapping : Profile
    {

        public RepositoryMapping()
        {
            //VehicleMakes Mapping
            CreateMap<VehicleMakeEntity, VehicleMakeModels>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMakeModels>().ReverseMap();
            CreateMap<IVehicleMakeModels, VehicleMakeModels>().ReverseMap();

            CreateMap<VehicleMakeArgs, VehicleMakeEntity>().ReverseMap();
            
            //VehicleModels Mapping
            CreateMap<VehicleModelEntity, VehicleModelModels>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModelModels>().ReverseMap();
            CreateMap<IVehicleModelModels, VehicleModelModels>().ReverseMap();

            CreateMap<VehicleModelArgs, VehicleModelEntity>().ReverseMap();
            
            
            
        }

    }

}