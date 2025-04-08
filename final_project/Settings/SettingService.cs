using final_project.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.Settings
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;

        public SettingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ToggleMaintenanceModeAsync()
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == 1);
            if (setting == null) throw new Exception("Setting not found");

            setting.MaintenanceMode = !setting.MaintenanceMode;
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> GetMaintenanceModeAsync()
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == 1);
            if (setting == null) throw new Exception("Setting not found");

            return setting.MaintenanceMode;
        }
    }
}
