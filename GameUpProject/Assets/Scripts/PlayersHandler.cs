using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : MonoBehaviour
{
    public GameObject[] players;
    public int currentPlayerIndex;
    public PlayersHandler Instance;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = 0;
    }

    public GameObject NextPlayer()
    {
        return players[(currentPlayerIndex + 1) % players.Length];
    }
    public int NextIndex()
    {
        return (currentPlayerIndex + 1) % players.Length;
    }

    public void EndCurrentPlayersTurn()
    {
        currentPlayerIndex = (++currentPlayerIndex) % players.Length;
    }



}
