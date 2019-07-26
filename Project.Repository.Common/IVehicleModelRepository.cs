using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        int AddToVehicleModel(PostVehicleArgs post);
        int UpdateVehicleModel(VehicleModelArgs modelmodel);
        List<IVehicleModelModels> GetAllVehicleModel();
        int RemoveFromVehicleModel(int id);
        
    }
}