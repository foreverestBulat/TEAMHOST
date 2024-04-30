using System.Net;
using LiveStreamingServerNet;
using LiveStreamingServerNet.Flv.Installer;
using LiveStreamingServerNet.Networking.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

using var liveStreamingServer = LiveStreamingServerBuilder.Create()
    .ConfigureRtmpServer(options => options.AddFlv())
    .ConfigureLogging(options => options.AddConsole())
    .Build();

builder.Services.AddRazorPages();
builder.Services.AddBackgroundServer(liveStreamingServer, new IPEndPoint(IPAddress.Any, 1935));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/MyStream", async context =>
//    {
//        // Получаем поток видео из OBS Studio.
//        var videoStream = context.Request.Body;

//        // Рассылаем поток видео всем подключенным клиентам.
//        using var memoryStream = new MemoryStream();
//        await videoStream.CopyToAsync(memoryStream);
//        await context.Response.Body.WriteAsync(memoryStream.ToArray());
//    });
//});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
