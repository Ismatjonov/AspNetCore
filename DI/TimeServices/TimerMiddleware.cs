namespace DI;

public class TimerMiddleware
{
    RequestDelegate next;
    TimeService timeService;

    public TimerMiddleware(RequestDelegate next, TimeService timeService)
    {
        this.next = next;
        this.timeService = timeService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/time")
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"<h1>Current time: {timeService?.Time}</h1>");
        }
        else
        {
            await next.Invoke(context);
        }
    }
}