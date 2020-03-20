using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float numberOfLaps;
    public PlayerBoardState[] playerBoardStates;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public string ReturnName(int number)
    {
        return playerBoardStates[number].name;
    }
    public void PlayerDeath(PlayerClass[] players)
    {
    }
    private void StateOfFinishGame() 
    {
        
    }
    private void GameFinished()
    {
        SceneManager.LoadScene(1);
    }
}
