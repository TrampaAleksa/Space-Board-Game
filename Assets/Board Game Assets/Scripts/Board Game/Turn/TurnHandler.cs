using UnityEngine;

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
            return;
        }
        // player ended turn sound
        EndTurn.StartNextPlayersTurn();
        InstanceManager.Instance.Get<CameraMovementHandler>().DelayedFreeLookCameraModeSwitch(1.5f);
    }

    public GameObject AddPlayerTurnsToSkip(GameObject player, int turnsToSkip)
    {
        player.GetComponent<PlayerMovement>().turnsToSkip += turnsToSkip;
        return player;
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