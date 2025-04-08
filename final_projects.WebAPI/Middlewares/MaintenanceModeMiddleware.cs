using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using final_project.Data.Settings;

namespace final_project.WebAPI.Middlewares
{
    public class MaintenanceModeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public MaintenanceModeMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Allow the toggle endpoint even during maintenance
            var path = context.Request.Path.Value?.ToLower();

            if (path != null && path.Contains("/api/settings/toggle"))
            {
                await _next(context);
                return;
            }

            using var scope = _scopeFactory.CreateScope();
            var settingService = scope.ServiceProvider.GetRequiredService<ISettingService>();

            var maintenanceMode = await settingService.GetMaintenanceModeAsync();

            if (maintenanceMode && !context.User.IsInRole("Admin"))
            {
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync("🚧 The system is currently in maintenance mode.");
                return;
            }

            await _next(context);
        }
    }
}
