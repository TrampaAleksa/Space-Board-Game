using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Newtonsoft.Json;
using UnityEngine;

public class GameConfig
{
    private static Dictionary<Type, ConfigData> _dataDictionary = new();

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

    public static GameConfig FromJson(string json)
    {
        var gameConfig = JsonConvert.DeserializeObject<GameConfig>(json);
        if (gameConfig == null) // TODO -Deserialize object wont return null - will throw exception instead - handle it
        {
            Debug.LogError("Serialization of GameConfig failed and returned null! Using default config.");
            gameConfig = GetDefaultConfig();
        }
        
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