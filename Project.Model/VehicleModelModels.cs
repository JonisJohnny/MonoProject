using System;

using Project.Model.Common;

namespace Project.Model
{
    public class VehicleModelModels : IVehicleModelModels
    {
        public Guid Id { get; set; }
        public Guid Makeid { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
