
using Project.Model.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs);
        Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs);
        Task<IPagedCollection<IVehicleMakeModels>> GetAllVehicleMakeAsync(string tableSortOrder, int pageIndex, int itemsPerPage, string searchTabel);
        Task<IVehicleMakeModels> GetOneItemVehicleMakeAsync(string search);
        Task<int> RemoveFromVehicleMakeAsync(Guid id);

    }

}