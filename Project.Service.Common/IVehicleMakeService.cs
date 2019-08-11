
using System.Threading.Tasks;
using Project.Model.Common;
using System.Collections.Generic;
using System;


namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        
        Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs);
        Task<List<IVehicleMakeModels>> GetAllVehicleMakeAsync(string tableSortOrder, int pageIndex, int itemsPerPage, string searchTabel);
        Task<IVehicleMakeModels> GetOneItemVehicleMakeAsync(string search);
        Task<int> RemoveFromVehicleMakeAsync(Guid id);
    }

}