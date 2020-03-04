﻿using UnityEngine;

public class TurnHandler : MonoBehaviour, IBoardState
{
    public void EndCurrentPlayersTurn()
    {
        PlayersHandler playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        playersHandler.SetToNextPlayer();
        bool brokenEngines = playersHandler.GetCurrentPlayer().GetComponent<PlayerMovement>().EnginesBroken();
        if (brokenEngines)
        {
            BrokenEngines.BrokenEngineAction();
        }
        else
        {
            // player ended turn sound
            EndTurn.StartNextPlayersTurn();
            Invoke("DelayCameraModeSwitch", 1.5f);
        }
    }

    private void DelayCameraModeSwitch()
    {
        CameraMovementHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraMovementHandler>();
        cameraMovementHandler.SetCameraMode(cameraMovementHandler.freeLookMode);
    }

    public GameObject PlayerSkipTurns(GameObject player, int turnsToSkip)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip += turnsToSkip;
        return player;
    }

    public int SkipPlayersTurn(GameObject player)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip--;
        return player.GetComponent<PlayerMovement>().turnsToSkip;
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int turnsToSkip = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].turnsToSkip = player.GetComponent<PlayerMovement>().turnsToSkip;
            print("Saving the players turns to skip : " + turnsToSkip);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int turnsToSkip = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].turnsToSkip;
            player.GetComponent<PlayerMovement>().turnsToSkip = turnsToSkip;
            i++;
        }
    }
}