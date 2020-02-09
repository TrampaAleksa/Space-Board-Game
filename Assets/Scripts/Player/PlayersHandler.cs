using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : MonoBehaviour
{
    public GameObject[] players;
    //cilj je da rad sa ovim indeksima potpuno izbacimo iz svih klasa
    private int currentPlayerIndex;
    private int currentlySelectedPlayerIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize()
    {
        CurrentPlayerIndex = 0;
        CurrentlySelectedPlayerIndex = 0;
    }
    public GameObject NextPlayer()
    {
        return players[(CurrentPlayerIndex + 1) % players.Length];
    }
    public int NextIndex()
    {
        return (CurrentPlayerIndex + 1) % players.Length;
    }

    public void EndCurrentPlayersTurn()
    {
        CurrentPlayerIndex = (++CurrentPlayerIndex) % players.Length;
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowTooltipForGivenTime
            (tooltipHandler.FindTooltipByGameObjectName("TooltipMessage"),
            GetCurrentPlayer().name + "s turn",
            TooltipHandler.TOOLTIP_TIME_SHORT);
        DiceRollHandler diceRollHandler = InstanceManager.Instance.Get<DiceRollHandler>();
        if (diceRollHandler.DiceIsLocked())
        {
            diceRollHandler.ChangeDiceLockState();
        }
    }

    public GameObject GetCurrentPlayer()
    {
        return players[CurrentPlayerIndex];
    }

    public GameObject GetSelectedPlayer()
    {
        return players[CurrentlySelectedPlayerIndex];
    }

    public GameObject SelectNextPlayer()
    {
        CurrentlySelectedPlayerIndex = (CurrentlySelectedPlayerIndex + 1) % players.Length;

        if (CurrentlySelectedPlayerIndex == CurrentPlayerIndex)
            CurrentlySelectedPlayerIndex = (currentlySelectedPlayerIndex + 1) % players.Length;

        GameObject currentlySelectedPlayer = players[CurrentlySelectedPlayerIndex];
        print("Currently selected player: " + currentlySelectedPlayer.name);
        return currentlySelectedPlayer;
    }

    public GameObject GetPlayer(int index)
    {
        return players[index];
    }
    public int CurrentPlayerIndex
    {
        get => currentPlayerIndex;
        set
        {
            CurrentlySelectedPlayerIndex = value;
            currentPlayerIndex = value;
        }
    }

    public int CurrentlySelectedPlayerIndex { get => currentlySelectedPlayerIndex; set => currentlySelectedPlayerIndex = value; }


}
