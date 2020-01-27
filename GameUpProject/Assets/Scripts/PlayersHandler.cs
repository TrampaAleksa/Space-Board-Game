using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : MonoBehaviour
{
    public GameObject[] players;
    public int currentPlayerIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = 0;
    }

    public void EndCurrentPlayersTurn()
    {
        currentPlayerIndex = (++currentPlayerIndex) % players.Length;
    }



}
