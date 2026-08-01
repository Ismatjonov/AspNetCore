namespace DI.CounterServices;

public class CounterMiddleware
{
    private RequestDelegate next;
    private int i = 0;

    public CounterMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService counterServices)
    {
        i++;
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync($"Request {i}; Counter {counter.Value}; Services: {counterServices.Counter.Value}");
    }
}