
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

        public async Task<int> AddToVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            return await Repository.AddToVehicleModelAsync(vehiclemodelargs);
        }
        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            return await Repository.UpdateVehicleModelAsync(vehiclemodelargs);
        }

        public async Task<List<IVehicleModelModels>> GetAllVehicleModelAsync(string sortOrder,Guid? filter, int page, int itempp, string search)
        {
            return await Repository.GetAllVehicleModelAsync(sortOrder,filter,page,itempp,search);
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