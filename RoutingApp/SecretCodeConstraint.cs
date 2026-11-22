namespace RoutingApp;

public class SecretCodeConstraint : IRouteConstraint
{
    private string secretCode;

    public SecretCodeConstraint(string secretCode)
    {
        this.secretCode = secretCode;
    }
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        return values[routeKey]?.ToString() == secretCode;
    }
}