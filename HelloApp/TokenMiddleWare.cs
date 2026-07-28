namespace HelloApp;

public class TokenMiddleWare
{
    public readonly RequestDelegate next;
    string pattern;

    public TokenMiddleWare(RequestDelegate next, string pattern)
    {
        this.next = next;
        this.pattern = pattern;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token != pattern)
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