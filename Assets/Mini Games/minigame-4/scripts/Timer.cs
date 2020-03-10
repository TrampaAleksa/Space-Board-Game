using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
     int[] playerScores = new int[4];
    int a, b, c, d;

    CollectablePLayer1 c1;
    CollectablePLayer2 c2;
    CollectablePLayer3 c3;
    CollectablePLayer4 c4;
    public PlayerBoardState[] playerStates;

    bool granica = true;


    public Text timerText;
    private float startTime;
    public float maxTime=60;
    

    void Start()
    {

        startTime = Time.time;

        c1 = FindObjectOfType<CollectablePLayer1>();
        c2 = FindObjectOfType<CollectablePLayer2>();
        c3 = FindObjectOfType<CollectablePLayer3>();
        c4 = FindObjectOfType<CollectablePLayer4>();
     
    }

    // Update is called once per frame
    void Update()
    {   
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        if (Time.time < maxTime)
        {
            timerText.text = minutes + ":" + seconds;
            a = c1.points;
            b = c2.points;
            c = c3.points;
            d = c4.points;

            print("poeni 1 " + a);
            print("poeni 2 " + b);
            print("poeni 3 " + c);
            print("poeni 4 " + d);
        }
        else if(Time.time>maxTime && granica==true)
        {
            //sortArray(playerScores);

            playerScores[0] = a;
            playerScores[1] = b;
            playerScores[2] = c;
            playerScores[3] = d;

            print("proslo 60 sek");
            bubbleSort(playerScores);

            if (c1.points == playerScores[0])
            {
                playerStates[0].rank = 4;
            }
            else if (c1.points == playerScores[1])
            {
                playerStates[0].rank = 3;
            }
            else if (c1.points == playerScores[2])
            {
                playerStates[0].rank = 2;
            }
            else if (c1.points == playerScores[3])
            {
                playerStates[0].rank = 1;
            }

            //////////////////////////////////////////////////

            if (c2.points == playerScores[0])
            {
                playerStates[1].rank = 4;
            }
            else if (c2.points == playerScores[1])
            {
                playerStates[1].rank = 3;
            }
            else if (c2.points == playerScores[2])
            {
                playerStates[1].rank = 2;
            }
            else if (c2.points == playerScores[3])
            {
                playerStates[1].rank = 1;
            }

            //////////////////////////////////////////////////

            if (c3.points == playerScores[0])
            {
                playerStates[2].rank = 4;
            }
            else if (c3.points == playerScores[1])
            {
                playerStates[2].rank = 3;
            }
            else if (c3.points == playerScores[2])
            {
                playerStates[2].rank = 2;
            }
            else if (c3.points == playerScores[3])
            {
                playerStates[2].rank = 1;
            }

            /////////////////////////////////////////////////

            if (c4.points == playerScores[0])
            {
                playerStates[3].rank = 4;
            }
            else if (c4.points == playerScores[1])
            {
                playerStates[3].rank = 3;
            }
            else if (c4.points == playerScores[2])
            {
                playerStates[3].rank = 2;
            }
            else if (c4.points == playerScores[3])
            {
                playerStates[3].rank = 1;
            }

            ////////////////////////////////////////////////////

            //TRAMPA PLIZ NEMOJ MI JEBATI MATER, OPTIMIZOVACU OVO GORE SA IFOVIMA

            print("niz je " + playerScores[0] + " " + playerScores[1] + " " + playerScores[2] + " " + playerScores[3]);
            granica = false;
            SceneManager.LoadScene(0);
        }
    }

    public static void bubbleSort(int[] a)
    {
        bool sorted = false;
        int temp;
        while (!sorted)
        {
            sorted = true;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                {
                    temp = a[i];
                    a[i] = a[i + 1];
                    a[i + 1] = temp;
                    sorted = false;
                }
            }
        }
    }

}
