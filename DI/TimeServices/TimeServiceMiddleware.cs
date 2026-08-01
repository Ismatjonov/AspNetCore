namespace DI;

public class TimeServiceMiddleware
{
    RequestDelegate next;
    ITimeService timeService;

    public TimeServiceMiddleware(RequestDelegate next, ITimeService timeService)
    {
        this.next = next;
        this.timeService = timeService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync($"<h1>Time: {timeService?.GetTime()}</h1>");
    }
}