
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
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        public VehicleController(IVehicleMakeService serviceMake, IVehicleModelService serviceModel, IMapper mapper)
        {
            this.ServiceMake = serviceMake;
            this.ServiceModel = serviceModel;
            _mapper = mapper;
        }
        protected IVehicleMakeService ServiceMake { get; private set; }
        protected IVehicleModelService ServiceModel { get; private set; }
        
        [HttpPost]
        [Route("add")]
        public async Task<int> AddToVehicleAsync(VehicleREST vehicleREST)
        {
                var guid = Guid.NewGuid();
                vehicleREST.vehiclemake.Id = guid;
                vehicleREST.vehiclemodel.Makeid = guid;
                VehicleMakeModels vmar = _mapper.Map<VehicleMakeModels>(vehicleREST.vehiclemake);
                VehicleModelModels vmor = _mapper.Map<VehicleModelModels>(vehicleREST.vehiclemodel);
                int addToVehicleMakeAsyncResult = await ServiceMake.AddToVehicleMakeAsync(vmar);
                int addToVehicleModelAsyncResult = await ServiceModel.AddToVehicleModelAsync(vmor);
                return addToVehicleMakeAsyncResult * addToVehicleModelAsyncResult;
        }
    }
}
