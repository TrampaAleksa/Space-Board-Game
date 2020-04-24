using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersRanking : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    bool cond1 = true;
    bool cond2 = true;
    bool cond3 = true;
    bool cond4= true;

    int brojac = 5;
    public PlayerBoardState[] playerStates;

    void Awake()
    {

        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        player3 = GameObject.FindGameObjectWithTag("Player 3");
        player4 = GameObject.FindGameObjectWithTag("Player 4");

        playerStates = BoardStateHolder.Instance.playerBoardStates;
    }



    void Update()
    {
        if (player1.transform.position.y < -6 && cond1==true)
        {
            cond1 = false;
            brojac--;
            playerStates[0].rank = brojac;

        }
        if (player2.transform.position.y < -6 && cond2 == true)
        {
            cond2 = false;
            brojac--;
            playerStates[1].rank = brojac;
        }
        if (player3.transform.position.y < -6 && cond3 == true)
        {
            cond3 = false;
            brojac--;
            playerStates[2].rank = brojac;
        }
        if (player4.transform.position.y < -6 && cond4 == true)
        {
            cond4 = false;
            brojac--;
            playerStates[3].rank = brojac;
        }
        if(cond1==false && cond2==false && cond3==false && cond4 == false)
        {
            var scoreBoardSceneIndex = 6;
            SceneManager.LoadScene(scoreBoardSceneIndex);
        }
    }
}
