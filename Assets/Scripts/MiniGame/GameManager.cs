using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerBoardState[] playerBoardStates;

    public static GameManager Instance;
    int brojac = 1;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayerFinishRace(string number) 
    {
        brojac++;
    }
}
