using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace final_project.Business.Filters
{
    public class TimeRestrictionFilter : IActionFilter
    {
        private readonly TimeSpan _startTime = new TimeSpan(11, 0, 0); // 11:00 AM
        private readonly TimeSpan _endTime = new TimeSpan(12, 0, 0); // 12:00 PM

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var currentTime = DateTime.Now.TimeOfDay;

            if (currentTime < _startTime || currentTime > _endTime)
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "Reservations can only be made between 11:00 AM and 12:00 PM."
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
