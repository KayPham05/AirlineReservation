using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AirlineReservation.WinForms.Models;

namespace AirlineReservation.WinForms.ViewModels;

public class FlightSearchViewModel : INotifyPropertyChanged
{
    private string _origin = string.Empty;
    private string _destination = string.Empty;
    private BindingList<Flight> _flights = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Origin
    {
        get => _origin;
        set
        {
            if (_origin != value)
            {
                _origin = value;
                OnPropertyChanged();
            }
        }
    }

    public string Destination
    {
        get => _destination;
        set
        {
            if (_destination != value)
            {
                _destination = value;
                OnPropertyChanged();
            }
        }
    }

    public BindingList<Flight> Flights
    {
        get => _flights;
        private set
        {
            if (_flights != value)
            {
                _flights = value;
                OnPropertyChanged();
            }
        }
    }

    public void UpdateFlights(IEnumerable<Flight> flights)
    {
        Flights = new BindingList<Flight>(new List<Flight>(flights));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
