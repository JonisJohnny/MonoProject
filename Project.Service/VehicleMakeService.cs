
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        protected IVehicleMakeRepository Repository { get; private set; }


        public async Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs)
        {
            return await Repository.AddToVehicleMakeAsync(vehicleMakeArgs);
        }

        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehicleMakeArgs)
        {
            return await Repository.UpdateVehicleMakeAsync(vehicleMakeArgs);
        }

        public async Task<IPagedCollection<IVehicleMakeModels>> GetAllVehicleMakeAsync(string tableSortOrder, int pageIndex, int itemsPerPage, string searchTabel)
        {
            
            return await Repository.GetAllVehicleMakeAsync(tableSortOrder,pageIndex,itemsPerPage,searchTabel);
            
        }

        public async Task<IVehicleMakeModels> GetOneItemVehicleMakeAsync(string search)
        {
            return await Repository.GetOneItemVehicleMakeAsync(search);
        }
        public async Task<int> RemoveFromVehicleMakeAsync(Guid id)
        {
            return await Repository.RemoveFromVehicleMakeAsync(id);
        }


    }

}