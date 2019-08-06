using Project.Common;
using Project.Model.Common;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;


namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<int> AddToVehicleModel(VehicleModelArgs vehiclemodelargs);
        Task<int> UpdateVehicleModel(VehicleModelArgs vehiclemodelargs);
        Task<List<IVehicleModelModels>> GetAllVehicleModel(string sortOrder, Guid? filter, int page, int itempp);
        Task<IVehicleModelModels> GetOneItemVehicleModel(string search);
        Task<int> RemoveFromVehicleModel(Guid id);
        
    }
}