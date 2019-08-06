
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


        public async Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs)
        {
            return await Repository.AddToVehicleMakeAsync(vehiclemakeargs);
        }

        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs)
        {
            return await Repository.UpdateVehicleMakeAsync(vehiclemakeargs);
        }

        public async Task<List<IVehicleMakeModels>> GetAllVehicleMakeAsync(string sortOrder, int page, int itempp, string search)
        {

            return await Repository.GetAllVehicleMakeAsync(sortOrder,page,itempp,search);
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