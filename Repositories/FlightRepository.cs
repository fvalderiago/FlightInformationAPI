using FlightInformationAPI.Data;
using FlightInformationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightInformationAPI.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _context;

        public FlightRepository(FlightDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync() =>
            await _context.Flights.ToListAsync();

        public async Task<Flight?> GetByIdAsync(int id) =>
            await _context.Flights.FindAsync(id);

        public async Task AddAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flight>> SearchAsync(string? airline, string? departureAirport, string? arrivalAirport, DateTime? from, DateTime? to, FlightStatus? status)
        {
            var query = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(airline))
                query = query.Where(f => f.Airline.Contains(airline));

            if (!string.IsNullOrEmpty(departureAirport))
                query = query.Where(f => f.DepartureAirport == departureAirport);

            if (!string.IsNullOrEmpty(arrivalAirport))
                query = query.Where(f => f.ArrivalAirport == arrivalAirport);

            if (from.HasValue)
                query = query.Where(f => f.DepartureTime >= from.Value);

            if (to.HasValue)
                query = query.Where(f => f.DepartureTime <= to.Value);

            if (status.HasValue)
                query = query.Where(f => f.Status == status.Value);

            return await query.ToListAsync();
        }
    }
}
