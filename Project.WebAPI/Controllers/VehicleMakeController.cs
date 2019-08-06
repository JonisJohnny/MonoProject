
using System.Collections.Generic;
using Project.Common;
using Project.Model.Common;
using Project.Service.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Project.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        public VehicleMakeController(IVehicleMakeService service)
        {
            this.Service = service;
        }
        protected IVehicleMakeService Service { get; private set; }
        
        [HttpPost]
        [Route("add")]
        public async Task<int> AddtoCars(VehicleMakeArgs vehiclemakeargs)
        {
            return await Service.AddToVehicleMake(vehiclemakeargs);
        }

        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            return await Service.UpdateVehicleMake(vehiclemakeargs);
        }
        [HttpGet]
        [Route("list/{sortOrder}&{page}&{itempp}")]
        public List<IVehicleMakeModels> GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            return Service.GetAllVehicleMake(sortOrder,page,itempp);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleMakeAsync(Guid id)
        {
            return await Service.RemoveFromVehicleMake(id);
        }
    }
}
