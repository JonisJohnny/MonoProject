using Project.Common;
using Project.Model.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<int> AddToVehicleMake(VehicleMakeArgs vehiclemakeargs);
        Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs);
        List<IVehicleMakeModels> GetAllVehicleMake(string sortOrder, int page, int itempp);
        Task<int> RemoveFromVehicleMake(Guid id);

    }

}