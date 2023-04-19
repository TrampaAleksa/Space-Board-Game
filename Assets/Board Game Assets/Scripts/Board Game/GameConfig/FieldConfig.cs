using System.Collections.Generic;
using Newtonsoft.Json;

public class FieldConfig : ConfigData {
    public bool isRandomized = false;
    public int numberOfFields = 64;
    public List<string> fields = new List<string> {
        "emptyField",
        "fuelStation",
        "healField",
        "dealDamageField",
        "takeDamageField",
        "breakOthersEngineField",
        "breakPlayerEngineField",
        "placeMineField",
        "mineField",
        "moveForwardField",
        "moveBackwardField",
        "stealFuelField",
        "swapPlacesField",
        "teleportField"
    };

    public static FieldConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<FieldConfig>(json);
    }
}