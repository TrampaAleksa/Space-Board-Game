using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using FileUtil = com.digitalmind.towertest.FileUtil;

public class GameConfigInitializer : MonoBehaviour
{
    private static bool isInitialized;
    
    private void Awake()
    {
        if (isInitialized) return;
        
        
        var gameConfigJson = FileUtil.ReadFromFIle("BoardGameConfigFile.txt");
        if (gameConfigJson == "File not found")
        {
            FileUtil.WriteToFile("BoardGameConfigFile.txt", JsonConvert.SerializeObject(GameConfig.GetDefaultConfig()));
            gameConfigJson = FileUtil.ReadFromFIle("BoardGameConfigFile.txt");
        }

        var gameConfig = GameConfig.FromJson(gameConfigJson);
        gameConfig.Init();

        isInitialized = true;
    }
}
