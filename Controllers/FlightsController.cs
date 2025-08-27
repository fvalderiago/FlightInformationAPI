using FlightInformationAPI.Models;
using FlightInformationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightInformationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _service;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(IFlightService service, ILogger<FlightsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET /api/flights
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _service.GetAllFlightsAsync();
            return Ok(flights);
        }

        // GET /api/flights/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _service.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        // POST /api/flights
        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] Flight flight)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateFlightAsync(flight);
            _logger.LogInformation("Created flight {FlightNumber}", created.FlightNumber);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT /api/flights/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            flight.Id = id;

            var updated = await _service.UpdateFlightAsync(id, flight);
            if (!updated) return NotFound();

            _logger.LogInformation("Updated flight {FlightNumber}", flight.FlightNumber);
            return NoContent();
        }

        // DELETE /api/flights/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var deleted = await _service.DeleteFlightAsync(id);
            if (!deleted) return NotFound();

            _logger.LogInformation("Deleted flight with Id {Id}", id);
            return NoContent();
        }

        // GET /api/flights/search
        [HttpGet("search")]
        public async Task<IActionResult> SearchFlights(
            [FromQuery] string? airline,
            [FromQuery] string? departureAirport,
            [FromQuery] string? arrivalAirport,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] FlightStatus? status)
        {
            var flights = await _service.SearchFlightsAsync(airline, departureAirport, arrivalAirport, from, to, status);
            return Ok(flights);
        }
    }
}
