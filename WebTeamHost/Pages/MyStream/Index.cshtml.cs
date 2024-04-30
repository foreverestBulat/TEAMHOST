using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System;
using System.Diagnostics;
using WebTeamHost.Services.OBS;

namespace WebTeamHost.Pages.MyStream
{
    public class IndexModel : PageModel
    {
        public async void OnGet()
        {
            //var obs = new OBSWebsocket();
            //obs.ConnectAsync("localhost:4455", "your-password");

            //var obs = await OBSWork.InitConnect();

            ////obs.StartStreaming();

            //var stream = obs.OBS.GetStreamServiceSettings();  //new StreamingService();
            //stream.Settings.Server = "rtmp://localhost:4455";
            //Console.WriteLine(stream.Settings);

            //obs.OBS.SetStreamServiceSettings(stream);
            //obs.OBS.StartStream();

            //while (obs.OBS.GetStreamStatus().IsActive)
            //{
            //    Console.WriteLine();
            //    Task.Delay(1000);
            //}


            //obs.OBS.GetStreamServiceSettings();

            //// Преобразуем кадр в изображение и отправляем его в представление.
            //var imageData = new ImageData(new Uint8ClampedArray(frame.Data), frame.Width, frame.Height);
            //ViewData["ImageData"] = imageData;


            // C:\Program Files\obs-studio\bin\64bit
            // var directory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\obs-studio\bin\64bit";
            // var fileName = "obs64.exe";

            // var path = Path.Combine(directory, fileName);

            // Process.Start(path, "-f dshow -i video=screen-capture-recorder -vf crop=1280:720:320:180 -r 30 -vcodec rawvideo -pix_fmt yuv420p -threads 0 -tune zerolatency -f mpegts udp://localhost:1234");
        }



        //public async void OnGet()
        //{
        //    //Console.WriteLine("MyStream");
        //    //var obsw = await OBSWork.InitConnect();
        //    //await Task.Delay(2000);
        //    //obsw.StartStreaming();
        //    //Console.WriteLine("MyStream");
        //    //await obsw.SetNeededScene();
        //    //obsw.StartStreaming();
        //}
    }
}
