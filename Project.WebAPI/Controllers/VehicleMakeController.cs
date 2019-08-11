
using System.Collections.Generic;
using Project.Model;
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
        public async Task<int> AddToVehicleMakeAsync(VehicleMakeREST vehicleMakeREST)
        {
                VehicleMakeModels vmr = _mapper.Map<VehicleMakeModels>(vehicleMakeREST);
                return await Service.AddToVehicleMakeAsync(vmr);
        }

        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleMakeAsync(VehicleMakeREST vehicleMakeREST)
        {
            VehicleMakeModels vmr = _mapper.Map<VehicleMakeModels>(vehicleMakeREST);
            return await Service.UpdateVehicleMakeAsync(vmr);
        }
        [HttpGet]
        [Route("list/{tableSortOrder}&{pageIndex}&{itemsPerPage}&{searchTabel}")]
        public async Task<List<VehicleMakeView>> GetAllVehicleMakeAsync(string tableSortOrder, int pageIndex, int itemsPerPage, string searchTabel)
        {
            return _mapper.Map<List<VehicleMakeView>>(await Service.GetAllVehicleMakeAsync(tableSortOrder,pageIndex,itemsPerPage,searchTabel));
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
