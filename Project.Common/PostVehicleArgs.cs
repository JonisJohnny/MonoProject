using System;

namespace Project.Common
{
    public class VehicleMakeArgs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
    public class VehicleModelArgs
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
