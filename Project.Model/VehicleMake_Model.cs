using Project.Model.Common;


namespace Project.Model
{
    public class VehicleMake_Model : IVehicleMake_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

    }
}