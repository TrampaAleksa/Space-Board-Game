using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeBoard : MonoBehaviour
{
    void Start()
    {
        MiniGameHandler miniGameHandler = InstanceManager.Instance.Get<MiniGameHandler>();
        if (miniGameHandler.SetupBoardOnLoad())
        {
            print("Not the first time");
        }
        else
        {
            SetupBoardFirstTime(miniGameHandler);
        }
    }

    private void SetupBoardFirstTime(MiniGameHandler miniGameHandler)
    {
        print("first time initialization");
        miniGameHandler.playersHandler.Initialize();
        GameObject[] players = miniGameHandler.playersHandler.players;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerMovement>().Initialize();
            players[i].GetComponent<PlayerFuel>().Initialize();
            players[i].GetComponent<PlayerHealth>().Initialize();
        }
    }

}
