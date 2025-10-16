using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirlineReservation.WinForms.Data;
using AirlineReservation.WinForms.Models;
using AirlineReservation.WinForms.Services.Api;
using AirlineReservation.WinForms.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.WinForms.Controllers;

public class FlightSearchController
{
    private readonly AirlineDbContext _dbContext;
    private readonly IAirlineApiClient _apiClient;
    private readonly FlightSearchViewModel _viewModel;

    public FlightSearchController(AirlineDbContext dbContext, IAirlineApiClient apiClient, FlightSearchViewModel viewModel)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        var recentFlights = await _dbContext.Flights
            .OrderByDescending(f => f.DepartureTime)
            .Take(10)
            .ToListAsync(cancellationToken);

        _viewModel.UpdateFlights(recentFlights);
    }

    public async Task SearchFlightsAsync(CancellationToken cancellationToken = default)
    {
        var flights = await _apiClient.GetFlightsAsync(_viewModel.Origin, _viewModel.Destination, cancellationToken);

        var trackedFlights = flights.Select(flight =>
        {
            var tracked = _dbContext.Flights.Local.FirstOrDefault(f => f.Id == flight.Id);
            if (tracked is not null)
            {
                _dbContext.Entry(tracked).CurrentValues.SetValues(flight);
                return tracked;
            }

            _dbContext.Attach(flight);
            return flight;
        }).ToList();

        _viewModel.UpdateFlights(trackedFlights);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
