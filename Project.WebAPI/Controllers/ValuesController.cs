
using System.Collections.Generic;
using Project.Common;
using Project.Model.Common;
using Project.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ValuesController(ICarsService service)
        {
            this.Service = service;
            
        }
        protected ICarsService Service { get; private set; }
        
        [HttpPost]
        [Route("addcarmodel")]
        public int AddtoCars(PostVehicleArgs post)
        {
            return Service.AddToVehicleModel(post);
        }
        [HttpPut]
        [Route("vehiclemake/update")]
        public int UpdateVehicleMake(VehicleMakeArgs make_model)
        {
            return Service.UpdateVehicleMake(make_model);
        }
        [HttpPut]
        [Route("vehiclemodel/update")]
        public int UpdateVehicleModel(VehicleModelArgs model_model)
        {
            return Service.UpdateVehicleModel(model_model);
        }
        [HttpGet]
        [Route("vehiclemakes/{sortOrder}&{page}&{itempp}")]
        public (List<IVehicleMake_Model>,int) GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            return Service.GetAllVehicleMake(sortOrder,page,itempp);
        }

        [HttpGet]
        [Route("vehiclemodels/{sortOrder}&{filter}&{page}&{itempp}")]
        public (List<IVehicleModel_Model>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp)
        {
            return Service.GetAllVehicleModel(sortOrder,filter,page,itempp);
        }

       [HttpDelete]
        [Route("vehicleMake/remove/{id}")]
        public int DeleteVehicleMakeAsync(int id)
        {
            return Service.RemoveFromVehicleMake(id);
        }
        [HttpDelete]
        [Route("vehicleModel/remove/{id}")]
        public int DeleteVehicleModelAsync(int id)
        {
            return Service.RemoveFromVehicleModel(id);
        }


    }
}
