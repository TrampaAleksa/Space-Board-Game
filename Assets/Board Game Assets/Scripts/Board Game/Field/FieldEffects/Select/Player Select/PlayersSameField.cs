using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSameField
{
    public static bool AllPlayersOnSameField()
    {
        GameObject[] players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        bool sameField = false;
        if (players[0].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath ==
            players[1].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath)
        {
            if (players[0].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath ==
            players[2].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath)
            {
                if (players[0].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath ==
                players[3].GetComponent<PlayerMovement>().currentPlayerField.IndexInPath)
                {
                    sameField = true;
                }
            }
        }

        return sameField;
    }
}