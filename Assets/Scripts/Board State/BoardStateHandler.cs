using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateHandler : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    void Start()
    {
        foreach(var stateComponent in InstanceManager.Instance.GetComponents<IBoardState>())
        {
            stateComponent.SetupState();
        }
    }

    public void SaveBoardState()
    {
        foreach (var stateComponent in InstanceManager.Instance.GetComponents<IBoardState>())
        {
            stateComponent.SaveState();
        }
    }
}
