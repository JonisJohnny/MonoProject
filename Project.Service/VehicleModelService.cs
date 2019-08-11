
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Project.Service
{
       public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }

        protected IVehicleModelRepository Repository { get; private set; }

        public async Task<int> AddToVehicleModelAsync(IVehicleModelModels vehicleModelArgs)
        {
            return await Repository.AddToVehicleModelAsync(vehicleModelArgs);
        }
        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehicleModelArgs)
        {
            return await Repository.UpdateVehicleModelAsync(vehicleModelArgs);
        }

        public async Task<List<IVehicleModelModels>> GetAllVehicleModelAsync(string tableSortOrder, string filterTableFromBrand, int pageIndex, int itemsPerPage, string searchTable)
        {
            return await Repository.GetAllVehicleModelAsync(tableSortOrder,filterTableFromBrand,pageIndex,itemsPerPage,searchTable);
        }
        public async Task<IVehicleModelModels> GetOneItemVehicleModelAsync(string search)
        {
            return await Repository.GetOneItemVehicleModelAsync(search);
        }
        public async Task<int> RemoveFromVehicleModelAsync(Guid id)
        {
            return await Repository.RemoveFromVehicleModelAsync(id);
        }
    }
}