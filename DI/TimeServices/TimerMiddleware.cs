namespace DI;

public class TimerMiddleware
{
    RequestDelegate next;
    public TimerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, TimeService timeService)
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