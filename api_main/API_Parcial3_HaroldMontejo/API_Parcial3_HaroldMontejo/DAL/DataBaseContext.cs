using API_Parcial3_HaroldMontejo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3_HaroldMontejo.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Hotels>().HasIndex(c => c.Name).IsUnique(); //Aquí creo un índice del campo Name para la tabla Countries
        modelBuilder.Entity<Rooms>().HasIndex("Name", "CountryId").IsUnique(); //Indices Compuestos
    }
}
