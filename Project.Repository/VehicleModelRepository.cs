
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System.Collections.Generic;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
     public class VehicleModelRepository : IVehicleModelRepository
    {

        private readonly IMapper _mapper;
        public VehicleModelRepository(CarsContext context, IMapper mapper)
        {
            this.Context = context;   
            _mapper = mapper;
        }

        protected CarsContext Context { get; private set; }
        
        public async Task<int> AddToVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            
            VehicleModelEntity vme = _mapper.Map<VehicleModelEntity>(vehiclemodelargs);
            Context.VehicleModel.Add(vme);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModels vehiclemodelargs)
        {
            VehicleModelEntity vme = _mapper.Map<VehicleModelEntity>(vehiclemodelargs);
            Context.VehicleModel.Update(vme);
            return await Context.SaveChangesAsync();
        }
    

        public async Task<List<IVehicleModelModels>> GetAllVehicleModelAsync(string sortOrder, Guid? filter, int page, int itempp, string search)
        {
                var vm = from p in Context.VehicleModel select p;

                switch (sortOrder)
                {
                    case "Model_desc":
                        vm = vm.OrderByDescending(m => m.Name);
                        break;
                    case "Id_":
                    case "Id_asc":
                        vm = vm.OrderBy(m => m.Id);
                        break;
                    case "Id_desc":
                        vm = vm.OrderByDescending(m => m.Id);
                        break;
                    case "Color_":
                    case "Color_asc":
                        vm = vm.OrderBy(m => m.Abrv);
                        break;
                    case "Color_desc":
                        vm = vm.OrderByDescending(m => m.Abrv);
                        break;
                    case "BrandId_":
                    case "BrandId_asc":
                        vm = vm.OrderBy(m => m.Makeid);
                        break;
                    case "BrandId_desc":
                        vm = vm.OrderByDescending(m => m.Makeid);
                        break;
                    default:
                        vm = vm.OrderBy(m => m.Name);
                        break;
                }

                if(filter != Guid.Empty){
                    vm = vm.Where(m => m.Makeid.Equals(filter));
                }
                
                if(search != "null"){
                    vm = vm.Where(s => s.Name.ToLower().Contains(search.ToLower()) || s.Abrv.ToLower().Contains(search.ToLower()));
                }
                
                vm = vm.Skip(itempp * page).Take(itempp);

                return new List<IVehicleModelModels>(_mapper.Map<List<VehicleModelModels>>(await vm.ToListAsync()));

        }
        
        public async Task<IVehicleModelModels> GetOneItemVehicleModelAsync(string search){

                var Item = await Context.VehicleModel.FirstOrDefaultAsync(s => s.Name.ToLower().Contains(search.ToLower()) || s.Abrv.ToLower().Contains(search.ToLower()));
                IVehicleModelModels im = _mapper.Map<IVehicleModelModels>(Item);
                return im;
          }
        
        public async Task<int> RemoveFromVehicleModelAsync(Guid id)
        {
                VehicleModelEntity Find = Context.VehicleModel.Find(id);
                if(Find != null){
                    Context.VehicleModel.Remove(Find);
                    return await Context.SaveChangesAsync(); 
                }else{
                    return 0;
                }

        }
       
    }

}