using Microsoft.EntityFrameworkCore;
using web_api_2023_II.DAL.Entities;

namespace web_api_2023_II.DAL
{
    public class DataBaseContext : DbContext
    {
        //Con este constructor me podre conectar a la BD, me brinda unas opciones de configuracion que ya estan
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique();
        }
        public DbSet<Country> Countries { get; set; }  //Esta linea me toma la clase Country y me la mappea en SQL SERVER para crear una tabla llamada COUNTRIES
        public DbSet<State> States { get; set; }
    }
 
}
