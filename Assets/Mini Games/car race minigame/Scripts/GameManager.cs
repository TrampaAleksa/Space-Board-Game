using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int count=0;
    public PlayerBoardState[] playerBoardStates;
    public PlayerClass[] players;
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public string ReturnName(int number)
    {
        return playerBoardStates[number].playerName;
    }
    public void PlayerDeath(PlayerClass player, CameraFollowController camera)
    {
        count++;
        camera.finishGame = true;
        camera.deathOrNot = true;
        PlayerClass tmp;
        for(int i=0;i<players.Length;i++)
            if(player.Distance>players[i].Distance)
            {
                tmp=players[i];
                players[i]=player;
                player=tmp;
            }
        if(count==4)
            GameFinished();
        else camera.ChangeIndex(camera.index);
    }
    private void GameFinished()
    {
        for(int i=0;i<playerBoardStates.Length;i++)
            for(int j=0;j<players.Length;j++)
                if(players[j].NameOfPlayer==playerBoardStates[i].playerName)
                    playerBoardStates[i].rank=j+1;
    }
}
