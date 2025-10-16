using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirlineReservation.WinForms.Controllers;
using AirlineReservation.WinForms.ViewModels;

namespace AirlineReservation.WinForms.Views;

public partial class MainForm : Form
{
    private readonly FlightSearchController _controller;
    private readonly FlightSearchViewModel _viewModel;

    public MainForm(FlightSearchController controller, FlightSearchViewModel viewModel)
    {
        _controller = controller;
        _viewModel = viewModel;
        InitializeComponent();
        BindViewModel();
    }

    private void BindViewModel()
    {
        originTextBox.DataBindings.Add(nameof(originTextBox.Text), _viewModel, nameof(_viewModel.Origin));
        destinationTextBox.DataBindings.Add(nameof(destinationTextBox.Text), _viewModel, nameof(_viewModel.Destination));
        flightsGridView.AutoGenerateColumns = true;
        flightsGridView.DataSource = _viewModel.Flights;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await LoadInitialDataAsync();
    }

    private async Task LoadInitialDataAsync()
    {
        try
        {
            await _controller.InitializeAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Không thể tải dữ liệu chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void searchButton_Click(object sender, EventArgs e)
    {
        try
        {
            await _controller.SearchFlightsAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Không thể tìm kiếm chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            await _controller.SaveChangesAsync();
            MessageBox.Show(this, "Đã lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Không thể lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
