using Microsoft.AspNetCore.Mvc;
using OBSWebsocketDotNet;

namespace WebTeamHost.Controllers;
public class ObsStreamController : Controller
{
    // Метод для получения потока с OBS Studio
    //public ActionResult GetObsStream()
    //{
    //    // Добавьте здесь код для подключения к OBS Studio и получения потока
    //    var obs = new OBSWebsocket();
    //    obs.ConnectAsync("http://localhost:5012", "bulat");


    //    // Пример кода для получения изображения с камеры через OBS Studio:
    //    var scene = obs.GetSceneList().Scenes.Where(scene => scene.Name == "StreamTeamHost");

    //    //obs.StartStream();
        
    //    //var cameraStream = obs.GetCameraStream();

    //    // Вернуть изображение в виде потока
    //    return File(cameraStream, "image/jpeg");
    //}

    // Метод для отправки потока на веб-сайт
    public async Task SendStreamToWebsite()
    {
        // Подключение к вашему веб-сайту для отправки потока

        // Пример кода для отправки потока на веб-сайт
        // await websiteConnection.SendStream(cameraStream);
    }
}