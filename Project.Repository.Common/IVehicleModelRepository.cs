﻿
using Project.Model.Common;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;


namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<int> AddToVehicleModelAsync(IVehicleModelModels vehicleModelArgs);
        Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehicleModelArgs);
        Task<IPagedCollection<IVehicleModelModels>> GetAllVehicleModelAsync(string tableSortOrder, string filterTableFromBrand, int pageIndex, int itemsPerPage, string searchTable);
        Task<IVehicleModelModels> GetOneItemVehicleModelAsync(string search);
        Task<int> RemoveFromVehicleModelAsync(Guid id);
        
    }
}