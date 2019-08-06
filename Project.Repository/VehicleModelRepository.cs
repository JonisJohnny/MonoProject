using Project.Common;
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
        
        public async Task<int> AddToVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            try 
            {
                VehicleModelEntity vme = _mapper.Map<VehicleModelEntity>(vehiclemodelargs);
                Context.VehicleModel.Add(vme);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> UpdateVehicleModel(VehicleModelArgs vehiclemodelargs)
        {
            try 
            {
                VehicleModelEntity vme = _mapper.Map<VehicleModelEntity>(vehiclemodelargs);
                Context.VehicleModel.Update(vme);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    

        public async Task<List<IVehicleModelModels>> GetAllVehicleModel(string sortOrder, Guid? filter, int page, int itempp)
        {
            try 
            {
                var vm = from p in Context.VehicleModel select p;

                switch (sortOrder)
                {
                    case "Brand_desc":
                        vm = vm.OrderByDescending(m => m.Name);
                        break;
                    case "Id_":
                    case "Id_asc":
                        vm = vm.OrderBy(m => m.Id);
                        break;
                    case "id_desc":
                        vm = vm.OrderByDescending(m => m.Id);
                        break;
                    case "Slogan_":
                    case "Slogan_asc":
                        vm = vm.OrderBy(m => m.Abrv);
                        break;
                    case "Slogan_desc":
                        vm = vm.OrderByDescending(m => m.Abrv);
                        break;
                    default:
                        vm = vm.OrderBy(m => m.Name);
                        break;
                }

                if(filter != Guid.Empty){
                    vm = vm.Where(m => m.MakeId.Equals(filter));
                }
                

                vm = vm.Skip(itempp * page).Take(itempp);

                return new List<IVehicleModelModels>(_mapper.Map<List<VehicleModelModels>>(await vm.ToListAsync()));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<IVehicleModelModels> GetOneItemVehicleModel(string search){
            
            try
            {
                var Item = await Context.VehicleModel.Where(s => s.Name.ToLower().Contains(search.ToLower()) || s.Abrv.ToLower().Contains(search.ToLower())).FirstOrDefaultAsync();
                IVehicleModelModels im = _mapper.Map<IVehicleModelModels>(Item);
                return im;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<int> RemoveFromVehicleModel(Guid id)
        {
            try 
            {
                Context.VehicleModel.Remove(Context.VehicleModel.Find(id));
                return await Context.SaveChangesAsync(); 
            }  
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
    }

}