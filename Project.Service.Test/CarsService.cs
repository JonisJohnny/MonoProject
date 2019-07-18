using Project.Common;
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
    public class CarsServiceTest
    {


        public void GetAllVehicleModelshouldgivelistandanumber()
        {

            //Arange
            list expected;

            //Act
            list actual = CarsService.GetAllVehicleModel(Brand_desc, 90, 0, 10);

            //Assert
            Assert.Equal(expected, actual);
            
            

        }

    }
}