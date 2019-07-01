using Project.Common;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service
{
    public class CarsService : ICarsService
    {
        public CarsService(ICarsRepository repository)
        {
            this.Repository = repository;
        }

        protected ICarsRepository Repository { get; private set; }


        public int AddToVehicleModel(PostVehicleArgs post)
        {
            return Repository.AddToVehicleModel(post);
        }

        public int UpdateVehicleMake(VehicleMakeArgs make_model)
        {
            return Repository.UpdateVehicleMake(make_model);
        }
        public int UpdateVehicleModel(VehicleModelArgs model_model)
        {
            return Repository.UpdateVehicleModel(model_model);
        }

        public (List<IVehicleModel_Model>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp)
        {


            
            var modelraw = (from mo in Repository.GetAllVehicleModel() select mo);
            if (filter != 0)
            {
                modelraw = modelraw.Where(mo => mo.MakeId.Equals(filter));
                
            }
            
            int modelcount = modelraw.ToList().Count;
            var model = modelraw;
        

            switch (sortOrder)
            {
                case "Model_desc":
                    model = model.OrderByDescending(mo => mo.Name);
                    break;
                case "Id_":
                case "Id_asc":
                    model = model.OrderBy(mo => mo.Id);
                    break;
                case "Id_desc":
                    model = model.OrderByDescending(mo => mo.Id);
                    break;
                case "Color_":
                case "Color_asc":
                    model = model.OrderBy(mo => mo.Abrv);
                    break;
                case "Color_desc":
                    model = model.OrderByDescending(mo => mo.Abrv);
                    break;
                case "BrandId_":
                case "BrandId_asc":
                    model = model.OrderBy(mo => mo.MakeId);
                    break;
                case "BrandId_desc":
                    model = model.OrderByDescending(mo => mo.MakeId);
                    break;
                default:
                    model = model.OrderBy(mo => mo.Name);
                    break;
            }
            model = model.Skip(itempp * page).Take(itempp);
            return (model.ToList(),modelcount);

        }

        public (List<IVehicleMake_Model>,int) GetAllVehicleMake(string sortOrder, int page, int itempp)
        {
            int makecount = (from ma in Repository.GetAllVehicleMake() select ma).ToList().Count;
            var make = (from ma in Repository.GetAllVehicleMake() select ma);


            switch (sortOrder)
            {
                case "Brand_desc":
                    make = make.OrderByDescending(ma => ma.Name);
                    break;
                case "Id_":
                case "Id_asc":
                    make = make.OrderBy(ma => ma.Id);
                    break;
                case "id_desc":
                    make = make.OrderByDescending(ma => ma.Id);
                    break;
                case "Slogan_":
                case "Slogan_asc":
                    make = make.OrderBy(ma => ma.Abrv);
                    break;
                case "Slogan_desc":
                    make = make.OrderByDescending(ma => ma.Abrv);
                    break;
                default:
                    make = make.OrderBy(ma => ma.Name);
                    break;
            }
            make = make.Skip(itempp * page).Take(itempp);
            return (make.ToList(),makecount);
        }

        public int RemoveFromVehicleMake(int id)
        {
            return Repository.RemoveFromVehicleMake(id);
        }
        public int RemoveFromVehicleModel(int id)
        {
            return Repository.RemoveFromVehicleModel(id);
        }

    }
}