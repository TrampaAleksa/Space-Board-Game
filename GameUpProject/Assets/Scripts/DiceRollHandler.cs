using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    public Text tDiceNumberRolled;
    public PlayersHandler playersHandler;

    public static int number;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private void Start()
    {
        number = 0;
    }
    public void RollTheDice()
    {
        number = Random.Range(minimumDiceNumber, maximumDiceNumber + 1);
        tDiceNumberRolled.text = number.ToString();
        MoveCurrentPlayer();
    }

    public void MoveCurrentPlayer()
    {
        playersHandler.players[playersHandler.currentPlayerIndex].GetComponent<PlayerMovement>().MoveNFields(number);
        playersHandler.currentPlayerIndex = (++playersHandler.currentPlayerIndex) % playersHandler.players.Length;
    }
}
