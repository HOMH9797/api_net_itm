using Microsoft.AspNetCore.Mvc;
using web_api_2023_II.DAL.Entities;
using web_api_2023_II.Domain.Interfaces;
using web_api_2023_II.Domain.Services;

namespace web_api_2023_II.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {

        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStatesByCountryIdAsync(countryId);
            if (states == null || !states.Any())
            {
                return NotFound();
            }
            return Ok(states);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateStateAsync(State state, Guid countryId)
        {
            try
            {
                var createdState = await _stateService.CreateStateAsync(state, countryId);
                if (createdState == null)
                {
                    return NotFound();
                }
                return Ok(createdState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El país {0} ya existe.", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Country>> GetStateByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido !!");
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null) return NotFound();
            return Ok(state);
        }

    }
}
