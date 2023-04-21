using Newtonsoft.Json;

public class TeleportConfig : ConfigData {
    public int teleportRange = 3;

    public static TeleportConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<TeleportConfig>(json);
    }
}