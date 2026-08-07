namespace DI.GeneratorServices;

public class ReadMiddleware
{
    RequestDelegate next;
    private IRead read;

    public ReadMiddleware(RequestDelegate _, IRead read)
    {
        this.read = read;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync($"Current value: {read.ReadValue()}");
    }
}