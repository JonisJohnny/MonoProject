
using Project.Model.Common;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Project.Service.Common
{


    public interface IVehicleModelService
    {
        Task<int> AddToVehicleModelAsync(IVehicleModelModels vehicleModelArgs);
        Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehicleModelArgs);
        Task<List<IVehicleModelModels>> GetAllVehicleModelAsync(string tableSortOrder, string filterTableFromBrand, int pageIndex, int itemsPerPage, string searchTable);
        Task<IVehicleModelModels> GetOneItemVehicleModelAsync(string search);
        Task<int> RemoveFromVehicleModelAsync(Guid id);
    }
}