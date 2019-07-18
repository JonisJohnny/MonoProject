using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Xunit;

namespace Project.Repository.Test
{
    public class CarsRepositoryTest
    {
        [Fact]
        public void GetAllVehicleMakeShuldreturnlist()
        {
            //Arange
            list expected;

            //Act
            list actual = CarsRepository.GetAllVehicleMake();

            //Assert
            Assert.Equal(expected, actual);
                       
        }

        
       
    }
}