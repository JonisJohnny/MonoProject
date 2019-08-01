
using System.Collections.Generic;

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
        public async Task<int> AddtoVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            return await Service.AddToVehicleModelAsync(vehiclemodelargs);
        }
        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            return await Service.UpdateVehicleModelAsync(vehiclemodelargs);
        }

        [HttpGet]
        [Route("list/{sortOrder}&{filter}&{page}&{itempp}")]
        public async Task<List<VehicleModelView>> GetAllVehicleModelAsync(string sortOrder, Guid? filter, int page, int itempp)
        {
            return _mapper.Map<List<VehicleModelView>>(await Service.GetAllVehicleModelAsync(sortOrder,filter,page,itempp));
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
