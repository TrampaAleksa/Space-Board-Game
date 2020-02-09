using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoardState
{
    public int pathIndex = 0;
    public float fuel = 0;
    public float health = 0;
    public int rank = 0;
}

public class BoardStateHolder : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("BoardState");
        //if there are multiple board states, destroy the copy
        if (obj != null && obj != gameObject)
        {
            Destroy(gameObject);
            print("destroyed");
        }
        DontDestroyOnLoad(gameObject);
        InitialSetup();
    }

    public void SetPlayersRank(int playerIndex, int rankToSet)
    {
        playerBoardStates[playerIndex].rank = rankToSet;
    }

    private void InitialSetup()
    {
        playerBoardStates = new PlayerBoardState[4];
        for (int i = 0; i < playerBoardStates.Length; i++)
        {
            playerBoardStates[i] = new PlayerBoardState();
            playerBoardStates[i].pathIndex = 0;
            playerBoardStates[i].health = InstanceManager.Instance.Get<HealthHandler>().startingAmount;
            playerBoardStates[i].fuel = InstanceManager.Instance.Get<FuelHandler>().startingAmount;
            playerBoardStates[i].rank = i+1;
        }
    }

}
