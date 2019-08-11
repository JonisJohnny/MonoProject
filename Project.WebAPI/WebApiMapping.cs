
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using AutoMapper;

namespace Project.WebAPI
{
    public class WebApiMapping : Profile
    {

        public WebApiMapping()
        {
            //VehicleMakes Mapping
            CreateMap<IVehicleMakeModels, VehicleMakeView>().ReverseMap();
            CreateMap<VehicleMakeREST, VehicleMakeModels>().ReverseMap();
           
            
            //VehicleModels Mapping
            CreateMap<IVehicleModelModels, VehicleModelView>().ReverseMap();
            CreateMap<VehicleModelREST, VehicleModelModels>().ReverseMap();
        }
                   
    }

}