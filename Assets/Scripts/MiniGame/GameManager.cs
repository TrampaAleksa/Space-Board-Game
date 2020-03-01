using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    
    private int brojac = 1;
    private int numberOfPlayersFinished=0;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayerFinishRace(string number) 
    {
        playerBoardStates[int.Parse(number) - 1].rank = brojac;
        Debug.Log("player rank: " + playerBoardStates[int.Parse(number) - 1].rank);
        Debug.Log("pleyer" + number);
        brojac++;
        numberOfPlayersFinished++;
        if (numberOfPlayersFinished == 4)
            GameFinished();
    }
    private void GameFinished() 
    {
        Time.timeScale = 0;
    }
}
