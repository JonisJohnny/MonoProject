using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;


namespace Project.Repository.Common
{
    public interface ICarsRepository
    {

        int AddToVehicleModel(PostVehicleArgs post);

        int UpdateVehicleMake(VehicleMakeArgs make_model);
        int UpdateVehicleModel(VehicleModelArgs model_model);

        List<IVehicleMake_Model> GetAllVehicleMake();

        List<IVehicleModel_Model> GetAllVehicleModel();

        int RemoveFromVehicleMake(int id);
        int RemoveFromVehicleModel(int id);


    }
}