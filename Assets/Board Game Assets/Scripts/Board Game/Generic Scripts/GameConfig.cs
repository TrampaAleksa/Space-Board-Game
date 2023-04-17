using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Newtonsoft.Json;
using UnityEngine;

public class GameConfig
{
    private Dictionary<Type, ConfigData> _dataDictionary = new();


    [JsonProperty(PropertyName = "fuelData")]
    private FuelConfigData _fuelData;
    [JsonProperty(PropertyName = "healthData")]
    private HealthConfigData _healthData;

    public GameConfig()
    {
        _fuelData = new FuelConfigData();
        _healthData = new HealthConfigData();
        
        AddConfig(_fuelData);
        AddConfig(_healthData);

        var fuelConfigData = GetConfig<FuelConfigData>();
        var fuelDataJson = JsonConvert.SerializeObject(fuelConfigData);
        Debug.Log("Fuel config data: " + fuelDataJson);
        Debug.Log("Fuel config data damage amount: " + fuelConfigData.fuelDamageAmount);

        var healthConfigData = GetConfig<HealthConfigData>();
        var healthDataJson = JsonConvert.SerializeObject(healthConfigData);
        Debug.Log("Health config data: " + healthDataJson);
        Debug.Log("Health config data damage amount: " + healthConfigData.healthDamageAmount);
    }

    public T GetConfig<T>() where T : ConfigData
    {
        return _dataDictionary[typeof(T)] as T;
    }

    public void AddConfig<T>(T config) where T : ConfigData
    {
        _dataDictionary.Add(typeof(T), config);
    }
}


public class ConfigData
{
    
}

public class FuelConfigData : ConfigData
{
    public float fuelDamageAmount = 10f;
}

public class HealthConfigData : ConfigData
{
    public float healthDamageAmount = 20f;
}
