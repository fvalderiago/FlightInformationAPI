using FlightInformationAPI.Models;

namespace FlightInformationAPI.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(int id);
        Task AddAsync(Flight flight);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(int id);
        Task<IEnumerable<Flight>> SearchAsync(string? airline, string? departureAirport, string? arrivalAirport, DateTime? from, DateTime? to, FlightStatus? status);
    }
}
