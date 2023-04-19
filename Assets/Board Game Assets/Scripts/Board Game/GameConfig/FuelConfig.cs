using Newtonsoft.Json;

public class FuelConfig : ConfigData {
    public float fuelForWin = 100f;
    public float fuelPerField = 0.5f;
    public float fuelToSteal = 20f;
    public float fuelPerCheckpoint = 10f;
    public float globalFuelGainModifier = 1.0f;
    public float globalFuelLossModifier = 1.0f;

    public static FuelConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<FuelConfig>(json);
    }
}