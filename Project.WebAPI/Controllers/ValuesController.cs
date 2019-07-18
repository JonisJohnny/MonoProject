
using System.Collections.Generic;
using Project.Common;
using Project.Model.Common;
using Project.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        public MakeController(IMakeService service)
        {
            this.Service = service;
        }
        protected IMakeService Service { get; private set; }
        
        [HttpPost]
        [Route("addcarmake")]
        public int AddtoCars(PostVehicleArgs post)
        {
            return Service.AddToVehicleMake(post);
        }

        [HttpPut]
        [Route("vehiclemake/update")]
        public int UpdateVehicleMake(VehicleMakeArgs makemodel)
        {
            return Service.UpdateVehicleMake(makemodel);
        }
        [HttpGet]
        [Route("vehiclemakes/{sortOrder}&{page}&{itempp}")]
        public (List<IVehicleMakeModels>,int) GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            return Service.GetAllVehicleMake(sortOrder,page,itempp);
        }

       [HttpDelete]
        [Route("vehicleMake/remove/{id}")]
        public int DeleteVehicleMakeAsync(int id)
        {
            return Service.RemoveFromVehicleMake(id);
        }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public ModelController(IModelService service)
        {
            this.Service = service;
        }

        protected IModelService Service { get; private set; }


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
