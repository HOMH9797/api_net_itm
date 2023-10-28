using Microsoft.EntityFrameworkCore;
using web_api_2023_II.DAL.Entities;
using web_api_2023_II.DAL;
using web_api_2023_II.Domain.Interfaces;

namespace web_api_2023_II.Domain.Services
{
    public class StateService : IStateService
    {
        public readonly DataBaseContext _context;
        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _context.States
                .Where(s => s.CountryId == countryId)
                .ToListAsync();
            return states;
        }
        public async Task<State> GetStateByIdAsync(Guid id)
        {
            //return await _context.Countries.FindAsync(id); // FindAsync es un metodo propio del DbContext(DbSet)
            //return await _context.Countries.FirstAsync(x => x.Id == id); // FirstAsync es un metodo de EF CORE
            return await _context.States.FirstOrDefaultAsync(x => x.Id == id);//EF Core
        }
        public async Task<State> CreateStateAsync(State state,Guid countryId)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                state.CountryId = countryId;
                state.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
                state.ModifiedDate = null;

                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> EditStateAsync(State state, Guid id)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state); //El metodo Update que es de EF CORE
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(c => c.Id == id);
                if (state == null) return null;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
