using Project.Common;
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

        public async Task<int> AddToVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            return await Repository.AddToVehicleModel(vehiclemodelargs);
        }
        public async Task<int> UpdateVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            return await Repository.UpdateVehicleModel(vehiclemodelargs);
        }

        public async Task<List<IVehicleModelModels>> GetAllVehicleModel(string sortOrder,Guid? filter, int page, int itempp)
        {
            return await Repository.GetAllVehicleModel(sortOrder,filter,page,itempp);
        }
        public async Task<IVehicleModelModels> GetOneItemVehicleModel(string search)
        {
            return await Repository.GetOneItemVehicleModel(search);
        }
        public async Task<int> RemoveFromVehicleModel(Guid id)
        {
            return await Repository.RemoveFromVehicleModel(id);
        }
    }
}