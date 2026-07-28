namespace HelloApp;

public class TokenMiddleWare
{
    public readonly RequestDelegate next;

    public TokenMiddleWare(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token != "12345678")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Invalid token!");
        }
        else
        {
            await next.Invoke(context);
        }
    }
}