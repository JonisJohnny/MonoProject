using System;

namespace Project.WebAPI
{
    public class VehicleMakeView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
    public class VehicleModelView
    {
        public Guid Id { get; set; }
        public Guid Makeid { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}