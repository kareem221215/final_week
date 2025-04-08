using Microsoft.AspNetCore.Mvc;

namespace final_project.Data.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPatch("toggle-maintenance")]
        public async Task<IActionResult> ToggleMaintenanceMode()
        {
            await _settingService.ToggleMaintenanceModeAsync();
            return Ok("✅ Maintenance mode toggled.");
        }

        [HttpGet("maintenance-status")]
        public async Task<IActionResult> GetMaintenanceMode()
        {
            var isOn = await _settingService.GetMaintenanceModeAsync();
            return Ok(new { maintenance = isOn });
        }
    }
}
