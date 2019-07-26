
using System.Collections.Generic;
using Project.Common;
using Project.Model.Common;
using Project.Service.Common;
using Microsoft.AspNetCore.Mvc;

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


        [HttpPut]
        [Route("vehiclemodel/update")]
        public int UpdateVehicleModel(VehicleModelArgs modelmodel)
        {
            return Service.UpdateVehicleModel(modelmodel);
        }

        [HttpGet]
        [Route("vehiclemodels/{sortOrder}&{filter}&{page}&{itempp}")]
        public (List<IVehicleModelModels>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp)
        {
            return Service.GetAllVehicleModel(sortOrder,filter,page,itempp);
        }

        [HttpDelete]
        [Route("vehicleModel/remove/{id}")]
        public int DeleteVehicleModelAsync(int id)
        {
            return Service.RemoveFromVehicleModel(id);
        }


    }
}
