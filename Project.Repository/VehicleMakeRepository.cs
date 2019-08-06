
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using AutoMapper;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IMapper _mapper;
        public VehicleMakeRepository(CarsContext context, IMapper mapper)
        {
            this.Context = context;   
            _mapper = mapper;
        }
        protected CarsContext Context { get; private set; }
        public async Task<int> AddToVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs)
        {
                VehicleMakeEntity vme = _mapper.Map<VehicleMakeEntity>(vehiclemakeargs);
                Context.VehicleMake.Add(vme);
                return await Context.SaveChangesAsync();    
        }
        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModels vehiclemakeargs)
        {
                VehicleMakeEntity vme = _mapper.Map<VehicleMakeEntity>(vehiclemakeargs);
                Context.VehicleMake.Update(vme);
                return await Context.SaveChangesAsync();
        }
        
        public async Task<List<IVehicleMakeModels>> GetAllVehicleMakeAsync(string sortOrder, int page, int itempp, string search)
        {
                var vm = from p in Context.VehicleMake select p;

                switch (sortOrder)
                {
                    case "Brand_desc":
                        vm = vm.OrderByDescending(m => m.Name);
                        break;
                    case "Id_":
                    case "Id_asc":
                        vm = vm.OrderBy(m => m.Id);
                        break;
                    case "Id_desc":
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
                
                if(search != "null"){
                    vm = vm.Where(s => s.Name.ToLower().Contains(search.ToLower()) || s.Abrv.ToLower().Contains(search.ToLower()));
                }

                vm = vm.Skip(itempp * page).Take(itempp);

                return new List<IVehicleMakeModels>(_mapper.Map<List<VehicleMakeModels>>(await vm.ToListAsync()));
        }
        
        public async Task<IVehicleMakeModels> GetOneItemVehicleMakeAsync(string search){
            
                var Item = await Context.VehicleMake.FirstOrDefaultAsync(s => s.Name.ToLower().Contains(search.ToLower()) || s.Abrv.ToLower().Contains(search.ToLower()));
                IVehicleMakeModels im = _mapper.Map<IVehicleMakeModels>(Item);
                return im;
        }
        
        public async Task<int> RemoveFromVehicleMakeAsync(Guid id)
        {
                VehicleMakeEntity Find = Context.VehicleMake.Find(id);
                if(Find != null){
                    Context.VehicleMake.Remove(Find);
                    return await Context.SaveChangesAsync(); 
                }else{
                    return 0;
                }
                

        }
       
    }

}