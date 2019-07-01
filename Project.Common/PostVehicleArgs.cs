
namespace Project.Common
{
    public class PostVehicleArgs
    {
        
        public int make_Id { get; set; }
        public string make_Name { get; set; }
        public string make_Abrv { get; set; }

        public int model_Id { get; set; }
        public int model_MakeId { get; set; }
        public string model_Name { get; set; }
        public string model_Abrv { get; set; }
        

    }
    public class VehicleMakeArgs
    {
        public int Id { get; set; }
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
