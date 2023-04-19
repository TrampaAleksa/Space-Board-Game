using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Newtonsoft.Json;
using UnityEngine;

public class GameConfig
{
    private Dictionary<Type, ConfigData> _dataDictionary = new();

    [JsonProperty(PropertyName = "FieldConfig")]
    public FieldConfig FieldConfig;

    [JsonProperty(PropertyName = "TeleportConfig")]
    public TeleportConfig TeleportConfig;

    [JsonProperty(PropertyName = "EnginesConfig")]
    public EnginesConfig EnginesConfig;

    [JsonProperty(PropertyName = "DamagesConfig")]
    public DamagesConfig DamagesConfig;

    [JsonProperty(PropertyName = "HealthConfig")]
    public HealthConfig HealthConfig;

    [JsonProperty(PropertyName = "FuelConfig")]
    public FuelConfig FuelConfig;

    public GameConfig FromJson(string json)
    {
        var gameConfig = JsonConvert.DeserializeObject<GameConfig>(json);
        if (gameConfig == null)
        {
            Debug.LogError("Serialization of GameConfig failed and returned null! Using default config.");
            gameConfig = GetDefaultConfig();
        }
        
        gameConfig.Init();
        return gameConfig;
    }

    public void Init()
    {
        AddConfig(FieldConfig);
        AddConfig(TeleportConfig);
        AddConfig(EnginesConfig);
        AddConfig(DamagesConfig);
        AddConfig(HealthConfig);
        AddConfig(FuelConfig);
    }

    public T GetConfig<T>() where T : ConfigData
    {
        return _dataDictionary[typeof(T)] as T;
    }

    public void AddConfig<T>(T config) where T : ConfigData
    {
        _dataDictionary.Add(typeof(T), config);
    }
    
    
    public static GameConfig GetDefaultConfig()
    {
        return new GameConfig
        {
            FieldConfig = new FieldConfig(),
            TeleportConfig = new TeleportConfig(),
            EnginesConfig = new EnginesConfig(),
            DamagesConfig = new DamagesConfig(),
            HealthConfig = new HealthConfig(),
            FuelConfig = new FuelConfig()
        };
    }
}


public class ConfigData
{
    
}

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

public class HealthConfig : ConfigData {
    public float healthOnStart = 100f;
    public float healthOnRepair = 35f;
    public DamagesConfig damages = new DamagesConfig();

    public static HealthConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<HealthConfig>(json);
    }
}

public class DamagesConfig : ConfigData{
    public float takeDamageFieldAmount = 30f;
    public float dealDamageFieldAmount = 20f;
    public float mineDamage = 25f;
}

public class EnginesConfig : ConfigData {
    public float turnsToBreakPlayerEngine = 1f;
    public float turnsToBreakOthersEngine = 1f;

    public static EnginesConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<EnginesConfig>(json);
    }
}

public class TeleportConfig : ConfigData {
    public float teleportRange = 3f;

    public static TeleportConfig FromJson(string json) {
        return JsonConvert.DeserializeObject<TeleportConfig>(json);
    }
}

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

