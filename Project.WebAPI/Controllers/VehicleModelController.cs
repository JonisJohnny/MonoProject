
using System.Collections.Generic;
using Project.Common;
using Project.Model.Common;
using Project.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Project.WebAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        public VehicleModelController(IVehicleModelService service)
        {
            this.Service = service;
        }

        protected IVehicleModelService Service { get; private set; }

        [HttpPost]
        [Route("add")]
        public async Task<int> AddtoVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            return await Service.AddToVehicleModel(vehiclemodelargs);
        }
        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            return await Service.UpdateVehicleModel(vehiclemodelargs);
        }

        [HttpGet]
        [Route("list/{sortOrder}&{filter}&{page}&{itempp}")]
        public async Task<List<IVehicleModelModels>> GetAllVehicleModel(string sortOrder, Guid? filter, int page, int itempp)
        {
            return await Service.GetAllVehicleModel(sortOrder,filter,page,itempp);
        }
        [HttpGet]
        [Route("item/{search}")]
        public async Task<IVehicleModelModels> GetOneItemVehicleModel(string search)
        {
            return await Service.GetOneItemVehicleModel(search);
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleModelAsync(Guid id)
        {
            return await Service.RemoveFromVehicleModel(id);
        }


    }
}
