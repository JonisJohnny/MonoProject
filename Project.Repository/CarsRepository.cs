using Project.Common;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System.Collections.Generic;
using AutoMapper;

namespace Project.Repository
{
    public class CarsRepository : ICarsRepository
    {
  

        public CarsRepository(CarsContext context)
        {
            this.Context = context;   
        }

        protected CarsContext Context { get; private set; }
        
      
        public int AddToVehicleModel(PostVehicleArgs postveargs)
        {
            VehicleMakeEntity vehiclemakeentity = new VehicleMakeEntity();
            vehiclemakeentity.Name = postveargs.make_Name;
            vehiclemakeentity.Abrv = postveargs.make_Abrv;
            VehicleModelEntity vehiclemodelentity = new VehicleModelEntity();
            VehicleMakeEntity findvehiclemake = Context.VehicleMake.Find(postveargs.make_Id);

            if(findvehiclemake == null){
                Context.VehicleMake.Add(vehiclemakeentity);
                Context.SaveChanges();
                vehiclemodelentity.MakeId = vehiclemakeentity.Id;
            }else{
                vehiclemakeentity.Id = postveargs.make_Id;
                vehiclemodelentity.MakeId = postveargs.make_Id;
            }
            vehiclemodelentity.Id = postveargs.model_Id;
            vehiclemodelentity.Name = postveargs.model_Name;
            vehiclemodelentity.Abrv = postveargs.model_Abrv;
            Context.VehicleModel.Add(vehiclemodelentity);
            return Context.SaveChanges();
            
             
        }
        public int UpdateVehicleMake(VehicleMakeArgs make_model)
        {
            VehicleMakeEntity vehiclemakeentity = new VehicleMakeEntity();
            vehiclemakeentity.Id = make_model.Id;
            vehiclemakeentity.Name = make_model.Name;
            vehiclemakeentity.Abrv = make_model.Abrv;
            Context.VehicleMake.Update(vehiclemakeentity);
            return Context.SaveChanges();
        }
        public int UpdateVehicleModel(VehicleModelArgs model_model)
        {
            VehicleModelEntity vehiclemodelentity = new VehicleModelEntity();
            vehiclemodelentity.Id = model_model.Id;
            vehiclemodelentity.Name = model_model.Name;
            vehiclemodelentity.Abrv = model_model.Abrv;
            vehiclemodelentity.MakeId = model_model.MakeId;
            Context.VehicleModel.Update(vehiclemodelentity);
            return Context.SaveChanges();
        }
      
        public List<IVehicleMake_Model> GetAllVehicleMake()
        {

            return new List<IVehicleMake_Model>(Mapper.Map<List<VehicleMake_Model>>(Context.VehicleMake));
                       
        }

        
        public List<IVehicleModel_Model> GetAllVehicleModel()
        {
            return new List<IVehicleModel_Model>(Mapper.Map<List<VehicleModel_Model>>(Context.VehicleModel));
        }
    
     
        public int RemoveFromVehicleMake(int id)
        {
             Context.VehicleMake.Remove(Context.VehicleMake.Find(id));
             return Context.SaveChanges();   
        }
        public int RemoveFromVehicleModel(int id)
        {
            Context.VehicleModel.Remove(Context.VehicleModel.Find(id));
            return Context.SaveChanges();
        }
       
    }
}