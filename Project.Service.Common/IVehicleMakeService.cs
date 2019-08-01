
using System.Threading.Tasks;
using Project.Model.Common;
using System.Collections.Generic;
using System;


namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        
        Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs);
        Task<List<IVehicleMakeModels>> GetAllVehicleMakeAsync(string sortOrder, int page, int itempp);
        Task<IVehicleMakeModels> GetOneItemVehicleMakeAsync(string search);
        Task<int> RemoveFromVehicleMakeAsync(Guid id);
    }

}