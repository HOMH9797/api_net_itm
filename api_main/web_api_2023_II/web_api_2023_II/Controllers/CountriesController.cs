using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using web_api_2023_II.DAL.Entities;
using web_api_2023_II.Domain.Interfaces;

namespace web_api_2023_II.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            if (countries == null || !countries.Any())
            {
                return NotFound();
            }
            return Ok(countries);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Country country)
        {
            try
            {
                var createdCountry = await _countryService.CreateCountryAsync(country);
                if (createdCountry == null)
                {
                    return NotFound();
                }
                return Ok(createdCountry);
            }catch(Exception ex)
            {
                if(ex.Message.Contains("duplicate")) {
                    return Conflict(String.Format("El país {0} ya existe.",country.Name));
                }
                return Conflict(ex.Message);
            }
        }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            if(id == null) return BadRequest("Id es requerido !!");
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpGet, ActionName("GetByName")]
        [Route("GetByName/{name}")]
        public async Task<ActionResult<Country>> GetCountryByNameAsync(string name)
        {
            if (name == null) return BadRequest("Nombre del país requerido !!");
            var country = await _countryService.GetCountryByNameAsync(name);
            if (country == null) return NotFound();
            return Ok(country);
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

            if (deletedCountry == null) return NotFound("Pais no encontrado!");

            return Ok(deletedCountry);
        }
    }
}
