using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System.Collections.Generic;
using AutoMapper;

namespace Project.Repository
{
    public class MakeRepository : IMakeRepository
    {
       

        public MakeRepository(CarsContext context, IMapper mapper, IModelRepository repos)
        {
            this.Context = context;   
            this.Resp = repos;
        }

        protected CarsContext Context { get; private set; }
        protected IModelRepository Resp { get; private set; }
        public int AddToVehicleMake(PostVehicleArgs postveargs)
        {
            VehicleMakeEntity findvehiclemake = Context.VehicleMake.Find(postveargs.makeId);
             if(findvehiclemake == null){
                VehicleMakeEntity vme = new VehicleMakeEntity();
                vme.Name = postveargs.makeName;
                vme.Abrv = postveargs.makeAbrv;
                Context.VehicleMake.Add(vme);
                Context.SaveChanges();
                postveargs.modelMakeId = vme.Id;
            
                return Resp.AddToVehicleModel(postveargs);
            }else{
                postveargs.modelMakeId = findvehiclemake.Id;
                return Resp.AddToVehicleModel(postveargs);
            }
            
            
        }
        public int UpdateVehicleMake(VehicleMakeArgs makemodel)
        {
            VehicleMakeEntity vme = Mapper.Map<VehicleMakeEntity>(makemodel);
            Context.VehicleMake.Update(vme);
            return Context.SaveChanges();
        }
        
        public List<IVehicleMakeModels> GetAllVehicleMake()
        {
            return new List<IVehicleMakeModels>(Mapper.Map<List<VehicleMakeModels>>(Context.VehicleMake));
        }
        
        public int RemoveFromVehicleMake(int id)
        {
             Context.VehicleMake.Remove(Context.VehicleMake.Find(id));
             return Context.SaveChanges();   
        }
       
    }
     public class ModelRepository : IModelRepository
    {


        public ModelRepository(CarsContext context, IMapper mapper)
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