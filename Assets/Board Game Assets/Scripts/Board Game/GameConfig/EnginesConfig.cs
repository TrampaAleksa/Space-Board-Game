using Newtonsoft.Json;

public class EnginesConfig : ConfigData {
    public int turnsToBreakPlayerEngine = 1;
    public int turnsToBreakOthersEngine = 1;

    public static EnginesConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<EnginesConfig>(json);
    }
}