
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using AutoMapper;
using System.Collections.Generic;
using System;

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
            CreateMap<PagedCollection<IVehicleMakeModels>, IPagedCollection<IVehicleMakeModels>>().ReverseMap();     
            CreateMap<IPagedCollection<IVehicleMakeModels>, PagedCollection<IVehicleMakeModels>>().ReverseMap();  
            //VehicleModels Mapping
            CreateMap<VehicleModelEntity, VehicleModelModels>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModelModels>().ReverseMap();
            CreateMap<IVehicleModelModels, VehicleModelModels>().ReverseMap();
            CreateMap<PagedCollection<IVehicleModelModels>, IPagedCollection<IVehicleModelModels>>().ReverseMap();     
            CreateMap<IPagedCollection<IVehicleModelModels>, PagedCollection<IVehicleModelModels>>().ReverseMap(); 
            
        }

    }

}