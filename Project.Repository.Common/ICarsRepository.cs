using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Repository.Common
{
    public interface IMakeRepository
    {

        int AddToVehicleMake(PostVehicleArgs post);

        int UpdateVehicleMake(VehicleMakeArgs makemodel);

        List<IVehicleMakeModels> GetAllVehicleMake();

        int RemoveFromVehicleMake(int id);

    }
    public interface IModelRepository
    {
        int AddToVehicleModel(PostVehicleArgs post);
        int UpdateVehicleModel(VehicleModelArgs modelmodel);
        List<IVehicleModelModels> GetAllVehicleModel();
        int RemoveFromVehicleModel(int id);
        
    }
}