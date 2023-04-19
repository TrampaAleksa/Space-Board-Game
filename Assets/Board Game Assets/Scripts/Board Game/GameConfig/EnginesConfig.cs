using Newtonsoft.Json;

public class EnginesConfig : ConfigData {
    public float turnsToBreakPlayerEngine = 1f;
    public float turnsToBreakOthersEngine = 1f;

    public static EnginesConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<EnginesConfig>(json);
    }
}