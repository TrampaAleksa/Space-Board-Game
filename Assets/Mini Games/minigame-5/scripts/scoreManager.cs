using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{

    public Rigidbody player1;
    public Rigidbody player2;
    public Rigidbody player3;
    public Rigidbody player4;

    public GameObject player1GO;
    public GameObject player2GO;
    public GameObject player3GO;
    public GameObject player4GO;

    int brojac = 5;

    bool cond1 = false;
    bool cond2 = false;
    bool cond3 = false;
    bool cond4 = false;

    void Start()
    {
        player1GO = GameObject.FindGameObjectWithTag("Player 1");
        player1 = player1GO.GetComponent<Rigidbody>();

        player2GO = GameObject.FindGameObjectWithTag("Player 2");
        player2 = player2GO.GetComponent<Rigidbody>();

        player3GO = GameObject.FindGameObjectWithTag("Player 3");
        player3 = player3GO.GetComponent<Rigidbody>();

        player4GO = GameObject.FindGameObjectWithTag("Player 4");
        player4 = player4GO.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (player1 != null && player1.transform.position.y < -2)
        {
            player1.transform.parent = null;
            print("Uso 1");
            brojac--;
            BoardStateHolder.Instance.playerBoardStates[0].rank = brojac;
            Destroy(player1GO);
            cond1 = true;
        }
        if (player2 != null && player2.transform.position.y < -2)
        {
            player2.transform.parent = null;
            print("Uso 2");
            brojac--;
            BoardStateHolder.Instance.playerBoardStates[1].rank = brojac;
            Destroy(player2GO);
            cond2 = true;
        }
        if (player3 != null && player3.transform.position.y < -2)
        {
            player3.transform.parent = null;
            print("Uso 3");
            brojac--;
            BoardStateHolder.Instance.playerBoardStates[2].rank = brojac;
            Destroy(player3GO);
            cond3 = true;
        }
        if (player4 != null && player4.transform.position.y < -2)
        {
            player4.transform.parent = null;
            print("Uso 4");
            brojac--;
            BoardStateHolder.Instance.playerBoardStates[3].rank = brojac;
            Destroy(player4GO);
            cond4 = true;
        }
        if(cond1 && cond2 && cond3 && cond4)
        {
            var scoreBoardSceneIndex = 6;
            SceneManager.LoadScene(scoreBoardSceneIndex);
        }

    }
}
