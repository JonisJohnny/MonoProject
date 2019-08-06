using Project.Common;
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


        public async Task<int> AddToVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            return await Repository.AddToVehicleMake(vehiclemakeargs);
        }

        public async Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            return await Repository.UpdateVehicleMake(vehiclemakeargs);
        }

        public List<IVehicleMakeModels> GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            return Repository.GetAllVehicleMake(sortOrder,page,itempp);
        }

        public async Task<int> RemoveFromVehicleMake(Guid id)
        {
            return await Repository.RemoveFromVehicleMake(id);
        }


    }

}