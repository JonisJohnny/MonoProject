using Project.Common;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Project.Service
{
       public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }

        protected IVehicleModelRepository Repository { get; private set; }

        public int UpdateVehicleModel(VehicleModelArgs modelmodel)
        {
            return Repository.UpdateVehicleModel(modelmodel);
        }

        public (List<IVehicleModelModels>,int) GetAllVehicleModel(string sortOrder, int filter, int page, int itempp)
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

        public int RemoveFromVehicleModel(int id)
        {
            return Repository.RemoveFromVehicleModel(id);
        }

    }
}