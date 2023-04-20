using Newtonsoft.Json;

public class HealthConfig : ConfigData {
    public float healthOnStart = 100f;
    public float healthOnRepair = 35f;

    public static HealthConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<HealthConfig>(json);
    }
}