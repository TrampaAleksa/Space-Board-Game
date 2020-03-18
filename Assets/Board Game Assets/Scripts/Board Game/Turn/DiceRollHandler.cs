using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    private DiceRoll diceRoll;
    public int numberRolled = 0;

    private bool diceLocked = false;

    private void Start()
    {
        diceRoll = new DiceRoll();
    }

    public void DiceWasClicked()
    {
        if (!diceLocked)
        {
            ChangeDiceLockState();
            StartCoroutine(diceRoll.RollTheDiceAnim());
        }
        else Debug.Log("Sorry, the dice is locked");
    }

    public bool ChangeDiceLockState()
    {
        return diceLocked = !diceLocked;
    }

    public bool DiceIsLocked()
    {
        return diceLocked;
    }
}