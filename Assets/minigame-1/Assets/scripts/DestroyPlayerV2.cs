using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerV2 : MonoBehaviour
{

    public static bool destroy1 = false;
    public static bool destroy2 = false;
    public static bool destroy3 = false;
    public static bool destroy4 = false;

    int brojac = 5;
    public PlayerBoardState[] playerStates;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player 1")
        {
            Destroy(other.gameObject);
            brojac--;
            playerStates[0].rank = brojac;
            destroy1 = true;
        }
        if (other.gameObject.tag == "Player 2")
        {
            Destroy(other.gameObject);
            brojac--;
            playerStates[1].rank = brojac;
            destroy2 = true;
        }
        if (other.gameObject.tag == "Player 3")
        {
            Destroy(other.gameObject);
            brojac--;
            playerStates[2].rank = brojac;
            destroy3 = true;
        }
        if (other.gameObject.tag == "Player 4")
        {
            Destroy(other.gameObject);
            brojac--;
            playerStates[3].rank = brojac;
            destroy4 = true;
        }
    }
}
