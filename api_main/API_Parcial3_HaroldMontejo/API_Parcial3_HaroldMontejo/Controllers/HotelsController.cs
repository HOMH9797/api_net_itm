using API_Parcial3_HaroldMontejo.DAL.Entities;
using API_Parcial3_HaroldMontejo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace API_Parcial3_HaroldMontejo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService _hotelsService;
        public HotelsController(IHotelsService hotelsService)
        {
            _hotelsService = hotelsService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Hotels>>> GetHotelsAsync()
        {
            var hotels = await _hotelsService.GetHotelsAsync();
            
            if(hotels == null || !hotels.Any()) return NotFound();

            return Ok(hotels);
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Hotels hotels)
        {
            try
            {
                var createdHotels = await _hotelsService.CreateHotelsAsync(hotels);
                return Ok(createdHotels);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", hotels.Name));

                return Conflict(ex.Message);
            }
        }
    }
}
