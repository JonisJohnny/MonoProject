using System;

namespace Project.WebAPI
{
    public class VehicleMakeREST
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
    public class VehicleModelREST
    {
        public Guid Id { get; set; }
        public Guid Makeid { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
    public class VehicleREST
    {
        public VehicleMakeREST vehiclemake { get; set; }
        public VehicleModelREST vehiclemodel { get; set; }
    }
}