using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Service.Common
{
    public interface IMakeService
    {
        
        int AddToVehicleMake(PostVehicleArgs post);
        int UpdateVehicleMake(VehicleMakeArgs makemodel);
           
        (List<IVehicleMakeModels>,int) GetAllVehicleMake(string sortOrder, int page, int itempp);
        
        int RemoveFromVehicleMake(int id);
    }

    public interface IModelService
    {
        int UpdateVehicleModel(VehicleModelArgs modelmodel);
           
        (List<IVehicleModelModels>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp);
        
        int RemoveFromVehicleModel(int id);
        
      
    }
}