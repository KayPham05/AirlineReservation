using System;
using System.Net.Http;
using System.Windows.Forms;
using AirlineReservation.WinForms.Controllers;
using AirlineReservation.WinForms.Data;
using AirlineReservation.WinForms.Services.Api;
using AirlineReservation.WinForms.ViewModels;
using AirlineReservation.WinForms.Views;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.WinForms;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var options = new DbContextOptionsBuilder<AirlineDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AirlineReservation;Trusted_Connection=True;")
            .Options;

        using var dbContext = new AirlineDbContext(options);
        var httpClient = new HttpClient { BaseAddress = new Uri("https://api.example.com/") };
        var apiClient = new AirlineApiClient(httpClient);
        var viewModel = new FlightSearchViewModel();
        var controller = new FlightSearchController(dbContext, apiClient, viewModel);
        var mainForm = new MainForm(controller, viewModel);

        Application.Run(mainForm);
    }
}
