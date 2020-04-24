using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{

    public Text playerScore1;
    public Text playerScore2;
    public Text playerScore3;
    public Text playerScore4;

    CollectablePLayer1 c1;
    CollectablePLayer2 c2;
    CollectablePLayer3 c3;
    CollectablePLayer4 c4;

    public int points1 = 0;
    public int points2 = 0;
    public int points3 = 0;
    public int points4 = 0;

    void Start()
    {
        c1 = FindObjectOfType<CollectablePLayer1>();
        c2 = FindObjectOfType<CollectablePLayer2>();
        c3 = FindObjectOfType<CollectablePLayer3>();
        c4 = FindObjectOfType<CollectablePLayer4>();
    }
    

    void Update()
    {
        points1 = c1.points;
        points2 = c2.points;
        points3 = c3.points;
        points4 = c4.points;

        playerScore1.text = "Player gray score: " + points1;
        playerScore2.text = "Player red score: " + points2;
        playerScore3.text = "Player yellow score: " + points3;
        playerScore4.text = "Player green score: " + points4;

    }
}
