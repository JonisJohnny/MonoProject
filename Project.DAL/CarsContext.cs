
using Microsoft.EntityFrameworkCore;


namespace Project.DAL
{
    public class CarsContext : DbContext
    {

        
            public DbSet<VehicleMakeEntity> VehicleMake { get; set; }
            public DbSet<VehicleModelEntity> VehicleModel { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=cars;Username=postgres;Password=root");
    }


}

