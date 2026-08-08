using RoutingApp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contact Page");

// it could be any objects
app.Map("/user", () => new Person("Bakhtovar", 20));

// doing nothing, just logging some message in console
app.Map("/log", () => Console.WriteLine("Request Path: /log"));

app.Run();