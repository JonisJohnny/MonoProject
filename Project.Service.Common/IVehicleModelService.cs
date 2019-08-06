using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Service.Common
{


    public interface IVehicleModelService
    {
        int UpdateVehicleModel(VehicleModelArgs modelmodel);
           
        (List<IVehicleModelModels>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp);
        
        int RemoveFromVehicleModel(int id);
        
      
    }
}