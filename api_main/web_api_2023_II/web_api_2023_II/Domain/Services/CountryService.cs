using Microsoft.EntityFrameworkCore;
using web_api_2023_II.DAL;
using web_api_2023_II.DAL.Entities;
using web_api_2023_II.Domain.Interfaces;

namespace web_api_2023_II.Domain.Services
{
    public class CountryService : ICountryService
    {
        public readonly DataBaseContext _context;
        public CountryService(DataBaseContext context) 
        { 
            _context = context;
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return country;
            }catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            //return await _context.Countries.FindAsync(id); // FindAsync es un metodo propio del DbContext(DbSet)
            //return await _context.Countries.FirstAsync(x => x.Id == id); // FirstAsync es un metodo de EF CORE
            return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);//EF Core
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
