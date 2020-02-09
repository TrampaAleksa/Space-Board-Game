using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : GenericObjectArray
{
    public GameObject[] players;
    //cilj je da rad sa ovim indeksima potpuno izbacimo iz svih klasa
    private int currentPlayerIndex;

    void Start()
    {
        CurrentPlayerIndex = 0;
        InstanceManager.Instance.Get<SelectionHandler>().CurrentlySelectedPlayerIndex = 0;
}

    public GameObject GetCurrentPlayer()
    {
        return CurrentMember();
    }

    public GameObject GetPlayerWithIndex(int index)
    {
        return MemberWithIndex(index);
    }

    public GameObject SetCurrentPlayer(int index)
    {
        return SetCurrentMember(index);
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
