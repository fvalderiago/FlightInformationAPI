using FlightInformationAPI.Models;
using FlightInformationAPI.Repositories;

namespace FlightInformationAPI.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;

        public FlightService(IFlightRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Flight>> GetAllFlightsAsync() => _repository.GetAllAsync();

        public Task<Flight?> GetFlightByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<Flight> CreateFlightAsync(Flight flight)
        {
            await _repository.AddAsync(flight);
            return flight;
        }

        public async Task<bool> UpdateFlightAsync(int id, Flight flight)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.FlightNumber = flight.FlightNumber;
            existing.Airline = flight.Airline;
            existing.DepartureAirport = flight.DepartureAirport;
            existing.ArrivalAirport = flight.ArrivalAirport;
            existing.DepartureTime = flight.DepartureTime;
            existing.ArrivalTime = flight.ArrivalTime;
            existing.Status = flight.Status;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteFlightAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public Task<IEnumerable<Flight>> SearchFlightsAsync(
            string? airline,
            string? departureAirport,
            string? arrivalAirport,
            DateTime? from,
            DateTime? to,
            FlightStatus? status)
            => _repository.SearchAsync(airline, departureAirport, arrivalAirport, from, to, status);
    }    
}
