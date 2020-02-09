using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : MonoBehaviour
{
    public GameObject[] players;
    //cilj je da rad sa ovim indeksima potpuno izbacimo iz svih klasa
    private int currentPlayerIndex;
   // private int currentlySelectedPlayerIndex;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayerIndex = 0;
        InstanceManager.Instance.Get<SelectionHandler>().CurrentlySelectedPlayerIndex = 0;
}

    public GameObject NextPlayer()
    {
        return players[(CurrentPlayerIndex + 1) % players.Length];
    }
    public int NextIndex()
    {
        return (CurrentPlayerIndex + 1) % players.Length;
    }
    public GameObject GetCurrentPlayer()
    {
        return players[CurrentPlayerIndex];
    }

    public GameObject GetPlayerWithIndex(int index)
    {
        return players[index];
    }

    public int CurrentPlayerIndex
    {
        get => currentPlayerIndex;
        set
        {
            InstanceManager.Instance.Get<SelectionHandler>().CurrentlySelectedPlayerIndex = value;
            currentPlayerIndex = value;
        }
    }

}
