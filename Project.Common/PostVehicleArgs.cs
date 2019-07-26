using System;

namespace Project.Common
{
    public class PostVehicleArgs
    {
        
        public int makeId { get; set; }
        public string makeName { get; set; }
        public string makeAbrv { get; set; }

        public int modelId { get; set; }
        public int modelMakeId { get; set; }
        public string modelName { get; set; }
        public string modelAbrv { get; set; }
        

    }
    public class VehicleMakeArgs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
    public class VehicleModelArgs
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
