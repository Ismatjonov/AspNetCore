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
/*app.Map(
    "{controller=Home}/{action=Index}/{id?}",
    (string controller, string action, string? id) =>
        $"Controller: {controller} \nAction: {action} \nId: {id}"
    );*/

// ---------- Passing an arbitrary number of parameters in a request ----------
/*app.Map("users/{**info}", (string? info) => $"User Info: {info}");
app.Map("/", () => "Index Page");*/

// Route restrictions
/*app.Map("/user/{id}", (int id) => $"User Id: {id}");
app.Map("/", () => "Index Page!");*/

/*app.Map("/user/{id:int}", (int id) => $"User Id: {id}");
app.Map("/`user/{active:bool}", (bool isActive) => $"Active User: {isActive}");
app.Map("/user/{date:datetime}", (DateTime date) => $"User Date: {date}");
app.Map("/user/{price:decimal}", (decimal price) => $"User Price: {price}");
app.Map("/user/{weight:double}", (double weight) => $"User Weight: {weight}");
app.Map("/user/{height:float}", (float height) => $"User Height: {height}");
app.Map("/user/{id:guid}", (Guid id) => $"User Guid: {id}");
app.Map("/user/{id:long}", (long id) => $"User Id: {id}");
app.Map("/user/{name:minLength(3)}", (string name) => $"User Name: {name}");
app.Map("/user/{name:maxLength(20)}", (string name) => $"User Name: {name}");
app.Map("/user/{name:length(10)}", (string name) => $"User Name: {name}");
app.Map("/user/{age:min(3)}", (int age) => $"User Age: {age}");
app.Map("/user/{age:max(20)}", (int age) => $"User Age: {age}");
app.Map("/user/{age:range(19, 99)}", (int age) => $"User Age: {age}");
app.Map("/user/{name:alpha}", (string name) => $"User Name: {name}");
app.Map("/user/{phone:regex(^\\d{{3}}-\\d{{3}}-\\d{{4}}$)}", (string phone) => $"Phone Number: {phone}");
app.Map("/user/{email:required}", (string email) => $"User Email: {email}");
app.Map("/", () => "Index Page!");*/

// ------ Combining the constraints --------
app.Map(
    "/users/{name:alpha:minLength(3)}/{age:int:range(18,110)}",
    (string name, int age) => $"User Age: {age} \nUser Name: {name}");
app.Map("/phonebook/{phone:regex(^992-\\d{{2}}-\\d{{3}}-\\d{{2}}-\\d{{2}}$)}/",
    (string phone) => $"Phone Number: {phone}");
app.Map("/", () => "Index Page");
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