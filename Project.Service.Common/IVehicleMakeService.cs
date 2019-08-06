using Project.Common;
using System.Threading.Tasks;
using Project.Model.Common;
using System.Collections.Generic;
using System;


namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        
        Task<int> AddToVehicleMake(VehicleMakeArgs vehiclemakeargs);
        Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs);
        Task<List<IVehicleMakeModels>> GetAllVehicleMake(string sortOrder, int page, int itempp);
        Task<IVehicleMakeModels> GetOneItemVehicleMake(string search);
        Task<int> RemoveFromVehicleMake(Guid id);
    }

}