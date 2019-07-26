using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System.Collections.Generic;
using AutoMapper;

namespace Project.Repository
{
     public class VehicleModelRepository : IVehicleModelRepository
    {


        public VehicleModelRepository(CarsContext context, IMapper mapper)
        {
            this.Context = context;   
        }

        protected CarsContext Context { get; private set; }
        
        public int AddToVehicleModel(PostVehicleArgs postveargs)
        {
            VehicleModelEntity vme = new VehicleModelEntity();
            vme.MakeId = postveargs.modelMakeId;
            vme.Name = postveargs.modelName;
            vme.Abrv = postveargs.modelAbrv;
            Context.VehicleModel.Add(vme);
            return Context.SaveChanges();

        }
        public int UpdateVehicleModel(VehicleModelArgs modelmodel)
        {
            VehicleModelEntity vme = Mapper.Map<VehicleModelEntity>(modelmodel);
            Context.VehicleModel.Update(vme);
            return Context.SaveChanges();
        }
    
        public List<IVehicleModelModels> GetAllVehicleModel()
        {
            return new List<IVehicleModelModels>(Mapper.Map<List<VehicleModelModels>>(Context.VehicleModel));
        }
    
        public int RemoveFromVehicleModel(int id)
        {
            Context.VehicleModel.Remove(Context.VehicleModel.Find(id));
            return Context.SaveChanges();
        }
       
    }

}