$structure = @"
Entities\Restaurant.cs
Entities\Reservation.cs
Entities\Customer.cs
DTOs\RestaurantDTO.cs
DTOs\ReservationDTO.cs
DTOs\CustomerDTO.cs
DTOs\CreateReservationRequest.cs
DTOs\UpdateReservationRequest.cs
Data\AppDbContext.cs
Data\SeedData.cs
Repositories\IGenericRepository.cs
Repositories\GenericRepository.cs
Repositories\IRestaurantRepository.cs
Repositories\IReservationRepository.cs
Repositories\ICustomerRepository.cs
Services\IRestaurantService.cs
Services\IReservationService.cs
Services\ICustomerService.cs
Services\RestaurantService.cs
Services\ReservationService.cs
Services\CustomerService.cs
Controllers\RestaurantsController.cs
Controllers\ReservationsController.cs
Controllers\CustomersController.cs
Middlewares\MaintenanceModeMiddleware.cs
Filters\TimeRestrictionFilter.cs
Settings\Setting.cs
Settings\ISettingService.cs
Settings\SettingService.cs
Settings\SettingsController.cs
Migrations\.placeholder
Program.cs
"@ -split "`n" | Where-Object { $_.Trim() -ne "" }

foreach ($line in $structure) {
    $path = $line.Trim()
    $dir = Split-Path $path -Parent
    if (!(Test-Path $dir)) {
        New-Item -ItemType Directory -Path $dir | Out-Null
    }
    if (!(Test-Path $path)) {
        New-Item -ItemType File -Path $path | Out-Null
    }
}

Write-Host "✅ All folders and files created!"