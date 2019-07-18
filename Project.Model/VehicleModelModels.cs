
using Project.Model.Common;

namespace Project.Model
{
    public class VehicleModelModels : IVehicleModelModels
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
