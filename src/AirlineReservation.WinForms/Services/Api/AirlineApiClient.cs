using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using AirlineReservation.WinForms.Models;

namespace AirlineReservation.WinForms.Services.Api;

public class AirlineApiClient : IAirlineApiClient
{
    private readonly HttpClient _httpClient;

    public AirlineApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<IReadOnlyList<Flight>> GetFlightsAsync(string origin, string destination, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"flights?origin={origin}&destination={destination}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var flights = await response.Content.ReadFromJsonAsync<List<Flight>>(cancellationToken: cancellationToken);
        return flights ?? new List<Flight>();
    }
}
