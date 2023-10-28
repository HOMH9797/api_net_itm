using API_Parcial3_HaroldMontejo.DAL;
using API_Parcial3_HaroldMontejo.DAL.Entities;
using API_Parcial3_HaroldMontejo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_Parcial3_HaroldMontejo.Domain.Services
{
    public class HotelsService : IHotelsService
    {

        private readonly DataBaseContext _context;

        public HotelsService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotels>> GetHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotels> CreateHotelsAsync(Hotels hotels)
        {
            try
            {
                hotels.Id = Guid.NewGuid();
                hotels.CreatedDate = DateTime.Now;

                _context.Hotels.Add(hotels);
                await _context.SaveChangesAsync();

                return hotels;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        
    }
}
