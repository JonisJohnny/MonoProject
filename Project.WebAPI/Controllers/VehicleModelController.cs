
using System.Collections.Generic;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IMapper _mapper;
        public VehicleModelController(IVehicleModelService service,IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }

        protected IVehicleModelService Service { get; private set; }

        [HttpPost]
        [Route("add")]
        public async Task<int> AddtoVehicleModelAsync(VehicleModelREST vehicleModelREST)
        {
            VehicleModelModels vmr = _mapper.Map<VehicleModelModels>(vehicleModelREST);
            return await Service.AddToVehicleModelAsync(vmr);
        }
        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleModelAsync(VehicleModelREST vehicleModelREST)
        {
            VehicleModelModels vmr = _mapper.Map<VehicleModelModels>(vehicleModelREST);
            return await Service.UpdateVehicleModelAsync(vmr);
        }

        [HttpGet]
        [Route("list/{tableSortOrder}&{filterTableFromBrand}&{pageIndex}&{itemsPerPage}&{searchTable}")]
        public async Task<IPagedCollection<VehicleModelREST>> GetAllVehicleModelAsync(string tableSortOrder, string filterTableFromBrand, int pageIndex, int itemsPerPage, string searchTable)
        {
            return _mapper.Map<IPagedCollection<VehicleModelREST>>(await Service.GetAllVehicleModelAsync(tableSortOrder,filterTableFromBrand,pageIndex,itemsPerPage,searchTable));
        }
        [HttpGet]
        [Route("item/{search}")]
        public async Task<VehicleModelView> GetOneItemVehicleModelAsync(string search)
        {
            return _mapper.Map<VehicleModelView>(await Service.GetOneItemVehicleModelAsync(search));
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleModelAsync(Guid id)
        {
            return await Service.RemoveFromVehicleModelAsync(id);
        }


    }
}
