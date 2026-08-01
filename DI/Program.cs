using System.Text;
using DI;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddMvc();
// var services = builder.Services;

// builder.Services.AddTransient<ITimeService, ShortTimeService>();

// builder.Services.AddTransient<TimeService>();

builder.Services.AddTransient<ITimeService, ShortTimeService>();
// builder.Services.AddTransient<TimeMessage>();

// builder.Services.AddTimeService();

var app = builder.Build();

/*app.Run(async (context) =>
{
    var sb = new StringBuilder();
    sb.Append("<h1>All Services</h1>");
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
    var timeService = app.Services.GetService<ITimeService>();
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
    var timeService = app.Services.GetRequiredService<ITimeService>();
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
app.UseMiddleware<TimeServiceMiddleware>();
app.Run();