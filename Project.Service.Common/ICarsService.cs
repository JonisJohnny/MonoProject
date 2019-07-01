using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Service.Common
{
    public interface ICarsService
    {
        
        int AddToVehicleModel(PostVehicleArgs post);
        int UpdateVehicleMake(VehicleMakeArgs make_model);
        int UpdateVehicleModel(VehicleModelArgs model_model);
           
        (List<IVehicleModel_Model>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp);
        
        (List<IVehicleMake_Model>,int) GetAllVehicleMake(string sortOrder, int page, int itempp);

        int RemoveFromVehicleMake(int id);
        int RemoveFromVehicleModel(int id);
        
      
    }
}