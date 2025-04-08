using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace final_project.Business.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;
        private Stopwatch _stopwatch;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Restart();
            _logger.LogInformation($"➡️ Starting {context.ActionDescriptor.DisplayName}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            _logger.LogInformation($"✅ Finished {context.ActionDescriptor.DisplayName} in {_stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
