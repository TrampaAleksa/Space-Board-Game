using Newtonsoft.Json;

public class TeleportConfig : ConfigData {
    public float teleportRange = 3f;

    public static TeleportConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<TeleportConfig>(json);
    }
}