using FlightInformationAPI.Models;

namespace FlightInformationAPI.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int id);
        Task<Flight> CreateFlightAsync(Flight flight);
        Task<bool> UpdateFlightAsync(int id, Flight flight);
        Task<bool> DeleteFlightAsync(int id);
        Task<IEnumerable<Flight>> SearchFlightsAsync(
            string? airline,
            string? departureAirport,
            string? arrivalAirport,
            DateTime? from,
            DateTime? to,
            FlightStatus? status
        );
    }
}
