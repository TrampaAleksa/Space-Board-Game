using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    public Text tDiceNumberRolled;
    private PlayersHandler playersHandler;

    public static int number;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private bool diceLocked = false;

    private void Start()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
        number = 0;
    }
    public void RollTheDice()
    {
        if (!diceLocked)
        {
            ChangeDiceLockState();
            number = Random.Range(minimumDiceNumber, maximumDiceNumber + 1);
            tDiceNumberRolled.text = number.ToString();
            MoveCurrentPlayer();
        }
        else Debug.Log("Sorry, the dice is locked");
    }

    public void MoveCurrentPlayer()
    {
        GameObject currentPlayer = playersHandler.GetCurrentPlayer();
        InstanceManager.Instance.Get<PlayerFieldMovement>().MoveNFields(number, currentPlayer);
    }

    public bool ChangeDiceLockState()
    {
        return diceLocked = !diceLocked;
    }

    public bool DiceIsLocked() { return diceLocked; }
}
