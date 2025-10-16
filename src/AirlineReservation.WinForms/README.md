# AirlineReservation.WinForms

Ứng dụng khách WinForms cho hệ thống đặt vé máy bay, tổ chức theo mô hình MVC với các lớp ViewModel để binding dữ liệu, controller điều phối nghiệp vụ, và lớp view WinForms thuần túy. Dự án sử dụng Entity Framework Core để làm việc với cơ sở dữ liệu SQL Server và có sẵn một dịch vụ gọi API để đồng bộ dữ liệu chuyến bay.

## Cấu trúc thư mục

```
AirlineReservation.WinForms/
├── AirlineReservation.WinForms.csproj
├── ApplicationConfiguration.cs
├── Program.cs
├── Controllers/
│   └── FlightSearchController.cs
├── Data/
│   └── AirlineDbContext.cs
├── Models/
│   └── Flight.cs
├── Services/
│   └── Api/
│       ├── AirlineApiClient.cs
│       └── IAirlineApiClient.cs
├── ViewModels/
│   └── FlightSearchViewModel.cs
└── Views/
    ├── MainForm.Designer.cs
    └── MainForm.cs
```

## Quy trình khởi tạo

`Program.cs` cấu hình `DbContext` của Entity Framework Core, khởi tạo `HttpClient` phục vụ gọi API, sau đó lắp ghép `FlightSearchController`, `FlightSearchViewModel` và `MainForm` theo đúng mô hình MVC.

## Thành phần chính

- **Controllers**: Xử lý luồng nghiệp vụ. `FlightSearchController` phối hợp dữ liệu giữa `DbContext`, API và ViewModel.
- **Data**: Định nghĩa `AirlineDbContext` với các entity, cấu hình bảng `Flights`.
- **Models**: Các entity thuần để lưu trữ dữ liệu (ví dụ `Flight`).
- **Services/Api**: Bao gồm interface và cài đặt của client gọi API REST bên ngoài.
- **ViewModels**: Cung cấp binding-friendly dữ liệu cho UI, triển khai `INotifyPropertyChanged`.
- **Views**: Các form WinForms thuần, kết nối sự kiện tới controller.

Các lớp và cấu trúc này là khởi điểm để mở rộng ứng dụng WinForms với các màn hình khác, tuân thủ MVC và dễ dàng kiểm thử.
