using System.Text;
using DI;
using DI.CounterServices;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
// builder.TimeServices.AddMvc();
// var services = builder.TimeServices;

// builder.TimeServices.AddTransient<ITimeService, ShortTimeService>();

// builder.TimeServices.AddTransient<TimeService>();

// builder.Services.AddTransient<ITimeService, ShortTimeService>();
// builder.TimeServices.AddTransient<TimeMessage>();

// builder.TimeServices.AddTimeService();

// using AddTransient()
/*builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();*/

// using AddScoped()
/*builder.Services.AddScoped<ICounter, RandomCounter>();
builder.Services.AddScoped<CounterService>();*/

// using AddSingleton()
/*builder.Services.AddSingleton<ICounter, RandomCounter>();
builder.Services.AddSingleton<CounterService>();*/
/*RandomCounter rndCounter = new RandomCounter();
builder.Services.AddSingleton<ICounter>(rndCounter);
builder.Services.AddSingleton<CounterService>(new CounterService(rndCounter));*/

// using services in middleware classes
// builder.Services.AddTransient<TimeService>();


// scoped-services in singleton-objects
/*builder.Services.AddTransient<ITimer, Timer>();
builder.Services.AddScoped<TimeService>();*/

var app = builder.Build();

/*app.Run(async (context) =>
{
    var sb = new StringBuilder();
    sb.Append("<h1>All TimeServices</h1>");
    sb.Append("<table border='1' cellpadding='0' cellspacing='0'>");
    sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Realization</th></tr>");
    foreach (var svc in services)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});*/

// =============== Creating services ===============
/*app.Run(async context =>
{
    var timeService = app.TimeServices.GetService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});*/

// -------- Service as a specific class --------
/*app.Run(async context =>
{
    var timeService = context.RequestServices.GetService<TimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});*/


// -------- Extension for adding services ----------
// code in line 11...

// ===================== Getting dependencies ====================
/*app.Run(async (context) =>
{
    var timeService = app.TimeServices.GetRequiredService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});*/


// ---------- HttpContext.RequestServices ----------
/*app.Run(async context =>
{
    var timeService = context.RequestServices.GetService<TimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});*/

// ---------- Constructors ----------
/*app.Run(async context =>
{
    var timeMessage = context.RequestServices.GetService<TimeMessage>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
});*/

// ---------- Method Invoke/InvokeAsync with middleware components ----------
/*app.UseMiddleware<TimeServiceMiddleware>();
app.Run();*/


// ==================== Life cycle of dependencies ====================
/*app.UseMiddleware<CounterMiddleware>();
app.Run();*/

// =============== Using services in middleware classes ===============
/*app.UseMiddleware<TimerMiddleware>();
app.Run(async context => await context.Response.WriteAsync("<h1>Hello Metanit.com</h1>"));
app.Run();*/

// ==================== Scoped-services in Singleton-objects ====================
/*app.UseMiddleware<TimerMiddleware>();
app.Run();*/