using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirlineReservation.WinForms.Models;

namespace AirlineReservation.WinForms.Services.Api;

public interface IAirlineApiClient
{
    Task<IReadOnlyList<Flight>> GetFlightsAsync(string origin, string destination, CancellationToken cancellationToken = default);
}
