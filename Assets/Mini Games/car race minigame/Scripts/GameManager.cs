using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int count=0;
    public PlayerBoardState[] playerBoardStates;
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public string ReturnName(int number)
    {
        return playerBoardStates[number].playerName;
    }
    public void PlayerDeath(int index, CameraFollowController camera)
    {
        count++;
        camera.finishGame = true;
        camera.deathOrNot = true;
        playerBoardStates[index].rank=count;
        if(count!=4)
            camera.ChangeIndex(camera.index);
        else SceneManager.LoadScene(1);
    }
}
