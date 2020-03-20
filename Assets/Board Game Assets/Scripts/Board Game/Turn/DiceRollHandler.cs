using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    private DiceRoll diceRoll;
    public bool isRandom = true;
    public int nonRandomNumber = 1;
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
            if(isRandom)
                StartCoroutine(diceRoll.RollTheDiceAnim());
            else
            {
                InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(nonRandomNumber);
            }
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