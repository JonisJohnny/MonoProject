
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Xunit;

namespace Project.Repository.Tests
{
    
    public class VehicleMakeRepositoryTest
    {
        public VehicleMakeRepositoryTest(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }
        protected IVehicleMakeRepository Repository { get; private set; }

        [Fact]
        public void GetAllVehicleMakeShuldreturnlist()
        {
            
            //Arange
            //Task<List<IVehicleMakeModels>> expected = new Task<List<IVehicleMakeModels>>(,1);

            //Act
            var actual = Repository.GetAllVehicleMakeAsync("null",0,1,"null");
           
            //Assert
            //Assert.Equal(expected, actual);
                       
        }

        
       
    }
}

