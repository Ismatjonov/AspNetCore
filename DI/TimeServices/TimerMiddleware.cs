namespace DI;

public class TimerMiddleware
{
    TimeService timeService;

    public TimerMiddleware(RequestDelegate next, TimeService timeService)
    {
        this.timeService = timeService;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync($"Time: {timeService.GetTime()}");
    }
}