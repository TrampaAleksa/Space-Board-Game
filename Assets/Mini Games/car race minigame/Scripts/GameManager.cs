using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float numberOfLaps;
    public PlayerBoardState[] playerBoardStates;

    private int counterRankInc = 1;
    private int counterRankDec = 4;
    private int numberOfPlayersFinished=0;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public string ReturnName(int number)
    {
        return playerBoardStates[number].name;
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
        playerBoardStates[number].rank = count;
        numberOfPlayersFinished++;
        if (numberOfPlayersFinished == 3)
            GameFinished();
    }
    private void GameFinished()
    {
        SceneManager.LoadScene(1);
    }
}
