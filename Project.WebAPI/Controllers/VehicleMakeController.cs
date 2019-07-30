﻿
using System.Collections.Generic;
using Project.Common;
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
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMapper _mapper;
        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }
        protected IVehicleMakeService Service { get; private set; }
        
        [HttpPost]
        [Route("add")]
        public async Task<int> AddToVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            return await Service.AddToVehicleMake(vehiclemakeargs);
        }

        [HttpPut]
        [Route("update")]
        public async Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            return await Service.UpdateVehicleMake(vehiclemakeargs);
        }
        [HttpGet]
        [Route("list/{sortOrder}&{page}&{itempp}")]
        public async Task<List<VehicleMakeView>> GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            return _mapper.Map<List<VehicleMakeView>>(await Service.GetAllVehicleMake(sortOrder,page,itempp));
        }
        [HttpGet]
        [Route("item/{search}")]
        public async Task<VehicleMakeView> GetOneItemVehicleMake(string search)
        {
            return _mapper.Map<VehicleMakeView>(await Service.GetOneItemVehicleMake(search));
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<int> DeleteVehicleMakeAsync(Guid id)
        {
            return await Service.RemoveFromVehicleMake(id);
        }
    }
}
