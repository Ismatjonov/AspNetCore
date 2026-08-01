namespace DI;

public class TimeServiceMiddleware
{
    readonly RequestDelegate next;

    public TimeServiceMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITimeService timeService)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync($"<h1>Time: {timeService?.GetTime()}</h1>");
    }
}