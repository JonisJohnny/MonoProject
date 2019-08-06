
using Project.Model.Common;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Project.Service.Common
{


    public interface IVehicleModelService
    {
        Task<int> AddToVehicleModelAsync(IVehicleModelModels vehiclemodelargs);
        Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehiclemodelargs);
        Task<List<IVehicleModelModels>> GetAllVehicleModelAsync(string sortOrder, Guid? filter, int page, int itempp, string search);
        Task<IVehicleModelModels> GetOneItemVehicleModelAsync(string search);
        Task<int> RemoveFromVehicleModelAsync(Guid id);
    }
}