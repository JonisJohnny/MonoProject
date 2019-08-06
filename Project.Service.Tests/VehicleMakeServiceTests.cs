
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Test
{
    public class VehicleMakeServiceTest
    {

        public VehicleMakeServiceTest(IVehicleMakeRepository service)
        {
            this.Service = service;
        }

        protected IVehicleMakeRepository Service { get; private set; }

        public void GetAllVehicleModelshouldgivelistandanumber()
        {

            
            //Arange
            //Task<List<IVehicleMakeModels>> expected = new Task<List<IVehicleMakeModels>>(,1);

            //Act
            var actual = Service.GetAllVehicleMakeAsync("null",0,1,"null");
           
            //Assert
            //Assert.Equal(expected, actual);
            
            

        }

    }
}