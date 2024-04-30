using OBSWebsocketDotNet;

namespace WebTeamHost.Services.OBS;


//1. `StartStreaming`: Начать трансляцию.
//2. `StopStreaming`: Остановить трансляцию.
//3. `GetCurrentScene`: Получить текущую сцену.
//4. `SetCurrentScene`: Установить текущую сцену.
//5. `GetSceneList`: Получить список доступных сцен.
//6. `GetStreamingStatus`: Получить статус трансляции.
//7. `GetSourcesList`: Получить список источников на текущей сцене.
//8. `SetSourceVisibility`: Установить видимость источника.
//9. `SetSourceSettings`: Установить настройки источника.
public class OBSWork
{
    public OBSWebsocket? OBS { get; set; }

    public static async Task<OBSWork> InitConnect()
    {
        var OBS = new OBSWebsocket();
        OBS.Connected += (sender, args) =>
        {
            if (OBS.IsConnected)
            {
                Console.WriteLine("Успешное подключение к OBS Studio.");
                // Здесь можно выполнять необходимые действия после успешного подключения
            }
        };

        OBS.ConnectAsync("ws://localhost:4455", "fTTcyovN39tLMqXq");

        // Ожидание подключения (желательно заменить на использование событий или задач)

        await WaitForConnection(OBS);

        if (!OBS.IsConnected)
        {
            Console.WriteLine("Не удалось подключиться к OBS Studio.");
        }

        await Task.Delay(2000);
        return new OBSWork() 
        { 
            OBS = OBS
        };
    }


    public async Task SetNeededScene(string sceneName="StreamTeamHost")
    {
        OBS.SetCurrentProgramScene(sceneName);
    }

    public static async Task WaitForConnection(OBSWebsocket obs)
    {
        while (!obs.IsConnected)
        {
            await Task.Delay(100); // Подождать некоторое время перед повторной проверкой
        }
    }

    public void StartStreaming()
    {
        OBS.StartStream();
    }

    public void StopStreaming()
    {

    }

    public void GetCurrentScene()
    {

    }

    public void SetCurrentScene(string sceneName)
    {

    }

    public void GetSceneList()
    {

    }

    public void GetStreamingStatus()
    {

    }

    public void GetSourcesList()
    {

    }

    public void SetSourceVisibility()
    {

    }

    public void SetSourceSettings()
    {

    }
}

