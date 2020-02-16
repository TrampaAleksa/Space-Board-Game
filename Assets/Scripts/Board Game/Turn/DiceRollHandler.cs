using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    public Text tDiceNumberRolled;

    public static int number = 0;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private bool diceLocked = false;

    public void RollTheDice()
    {
        if (!diceLocked)
        {
            ChangeDiceLockState();
            number = Random.Range(minimumDiceNumber, maximumDiceNumber + 1);
            tDiceNumberRolled.text = number.ToString();
            InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(number);
        }
        else Debug.Log("Sorry, the dice is locked");
    }

    public bool ChangeDiceLockState()
    {
        return diceLocked = !diceLocked;
    }

    public bool DiceIsLocked() { return diceLocked; }
}
