using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;

    private int counterRankInc = 1;
    public int counterRankDec = 4;
    private int numberOfPlayersFinished=0;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Win(int number) 
    {
            StateOfFinishGame(counterRankInc, number);
            counterRankInc++;
        
    }
    public void Lose(int number)
    {
            StateOfFinishGame(counterRankDec, number);
            counterRankDec--;
    }
    private void StateOfFinishGame(int count, int number)
    {
        playerBoardStates[number - 1].rank = count;
        numberOfPlayersFinished++;
        if (numberOfPlayersFinished == 3)
            GameFinished();
        Debug.Log("player rank: " + playerBoardStates[number-1].rank);
        Debug.Log("pleyer" + number);
    }
    private void GameFinished() 
    {
        Time.timeScale = 0;
    }
}
