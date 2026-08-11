using RoutingApp;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contact Page");
*/

// it could be any objects
// app.Map("/user", () => new Person("Bakhtovar", 20));

// doing nothing, just logging some message in console
// app.Map("/log", () => Console.WriteLine("Request Path: /log"));

// Putting route handler into the method
/*app.Map("/", IndexHandler);
app.Map("/user", UserHandler);*/

// another version of method with RequestDelegate
/*app.Map("/about", async context =>
{
    await context.Response.WriteAsync("About Page!");
});*/

// ---------- Getting all routes of app ----------
/*app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointDataSource) =>
    string.Join("\n", endpointDataSource.SelectMany(source => source.Endpoints)));*/

// getting detailed information
/*app.Map("/routes", (IEnumerable<EndpointDataSource> endpointsDataSource) =>
{
    var sb = new StringBuilder();
    var endpoints = endpointsDataSource.SelectMany(es => es.Endpoints);
    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);
        if (endpoint is RouteEndpoint routeEndpoint)
        {
            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
        }
    }

    return sb.ToString();
});
app.Run();*/


// ==================== Route Parameters ====================
/*app.Map("/users/{id}", (string id) => $"User Id: {id}");
app.Map("/users", () => "Users Page");
app.Map("/", () => "Index Page");*/

// ---------- Defining multiple parameters ----------
/*app.Map("/users/{id}/{name}", (string id, string name) => $"User Id: {id},  User Name: {name}");
app.Map("/users", () => "Users Page");
app.Map("/", () => "Index Page");*/

// ---------- Separators ----------
// app.Map("/users/{id}-{name}", (string id, string name) => $"User id: {id}, name: {name}");

/*app.Map("/users/{id}and{name}", (string id, string name) => $"User id is {id} and name is {name}");

app.Map("/", () => "Index Page");*/

// ---------- Moving the route handler into a separate method ----------
/*app.Map("/users/{id}/{name}", HandleRequest);
app.Map("/users", () => "Users Page");
app.Map("/", () => "Index Page");*/

// ---------- Optional route parameters ----------
/*app.Map("/users/{id?}", (string? id) => $"User Id: {id??"Undefined"}");
app.Map("/", () => "Index Page");*/

// --------- Default parameters values ---------
app.Map(
    "{controller=Home}/{action=Index}/{id?}",
    (string controller, string action, string? id) =>
        $"Controller: {controller} \nAction: {action} \nId: {id}"
    );

app.Run();

///////////////////////// Program Methods
string IndexHandler()
{
    return "Index Page";
}

Person UserHandler()
{
    return new Person("Bakhtovar", 20);
}

string HandleRequest(string id, string name)
{
    return $"User Id: {id}  User Name: {name}";
}