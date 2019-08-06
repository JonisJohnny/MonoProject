using Project.Common;
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
        public async Task<int> AddToVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            try 
            {
                VehicleMakeEntity vme = _mapper.Map<VehicleMakeEntity>(vehiclemakeargs);
                Context.VehicleMake.Add(vme);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<int> UpdateVehicleMake(VehicleMakeArgs vehiclemakeargs)
        {
            try 
            {
                VehicleMakeEntity vme = _mapper.Map<VehicleMakeEntity>(vehiclemakeargs);
                Context.VehicleMake.Update(vme);
                return await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        
        public List<IVehicleMakeModels> GetAllVehicleMake(string sortOrder, int page, int itempp)
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
            
            vm = vm.Skip(itempp * page).Take(itempp);

            return new List<IVehicleMakeModels>(_mapper.Map<List<VehicleMakeModels>>(vm));

        }
        
        public async Task<int> RemoveFromVehicleMake(Guid id)
        {
            try 
            {
                Context.VehicleMake.Remove(Context.VehicleMake.Find(id));
                return await Context.SaveChangesAsync(); 
            }  
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
    }

}