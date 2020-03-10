using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScores : MonoBehaviour
{
    CollectablePLayer1 c1;
    CollectablePLayer2 c2;
    CollectablePLayer3 c3;
    CollectablePLayer4 c4;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject[] players = new GameObject[4];
    int brojac = 0;


     void Start()
    {
        c1 = FindObjectOfType<CollectablePLayer1>();
        c2 = FindObjectOfType<CollectablePLayer2>();
        c3 = FindObjectOfType<CollectablePLayer3>();
        c4 = FindObjectOfType<CollectablePLayer4>();

        player1 = GameObject.FindGameObjectWithTag("Player 1");

        player2 = GameObject.FindGameObjectWithTag("Player 2");
     
        player3 = GameObject.FindGameObjectWithTag("Player 3");

        player4 = GameObject.FindGameObjectWithTag("Player 4");

    }

    void Update()
    {

    }

    public void sortPlayersByTheirScores()
    {
        for(int i = 0; i < players.Length; i++)
        {
            
        }
    }

}
