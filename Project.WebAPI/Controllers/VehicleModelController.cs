
using System.Collections.Generic;
using Project.Common;
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
        public async Task<List<VehicleModelView>> GetAllVehicleModel(string sortOrder, Guid? filter, int page, int itempp)
        {
            return _mapper.Map<List<VehicleModelView>>(await Service.GetAllVehicleModel(sortOrder,filter,page,itempp));
        }
        [HttpGet]
        [Route("item/{search}")]
        public async Task<VehicleModelView> GetOneItemVehicleModel(string search)
        {
            return _mapper.Map<VehicleModelView>(await Service.GetOneItemVehicleModel(search));
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleModelAsync(Guid id)
        {
            return await Service.RemoveFromVehicleModel(id);
        }


    }
}
