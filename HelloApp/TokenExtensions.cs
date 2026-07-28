namespace HelloApp;

public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleWare>();
    }
}