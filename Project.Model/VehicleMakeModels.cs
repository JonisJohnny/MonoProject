using Project.Model.Common;
using System;

namespace Project.Model
{
    public class VehicleMakeModels : IVehicleMakeModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        //List

    }
}