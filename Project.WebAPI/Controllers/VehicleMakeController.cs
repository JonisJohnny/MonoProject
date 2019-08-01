
using System.Collections.Generic;

using Project.Model.Common;
using Project.Service.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

namespace Project.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMapper _mapper;
        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }
        protected IVehicleMakeService Service { get; private set; }
        
        [HttpPost]
        [Route("add")]
        public async Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehiclemakerest)
        {
            return await Service.AddToVehicleMakeAsync(vehiclemakerest);
        }

        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehiclemakerest)
        {
            return await Service.UpdateVehicleMakeAsync(vehiclemakerest);
        }
        [HttpGet]
        [Route("list/{sortOrder}&{page}&{itempp}")]
        public async Task<List<VehicleMakeView>> GetAllVehicleMakeAsync(string sortOrder, int page, int itempp)
        {
            return _mapper.Map<List<VehicleMakeView>>(await Service.GetAllVehicleMakeAsync(sortOrder,page,itempp));
        }
        [HttpGet]
        [Route("item/{search}")]
        public async Task<VehicleMakeView> GetOneItemVehicleMakeAsync(string search)
        {
            return _mapper.Map<VehicleMakeView>(await Service.GetOneItemVehicleMakeAsync(search));
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleMakeAsync(Guid id)
        {
            return await Service.RemoveFromVehicleMakeAsync(id);
        }
    }
}
