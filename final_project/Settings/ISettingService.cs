namespace final_project.Data.Settings
{
    public interface ISettingService
    {
        Task ToggleMaintenanceModeAsync();
        Task<bool> GetMaintenanceModeAsync();
    }
}
