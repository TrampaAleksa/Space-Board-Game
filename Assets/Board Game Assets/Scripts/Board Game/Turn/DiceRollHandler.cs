using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    private DiceRollAsync diceRoll;
    public bool isRandom = true;
    public int nonRandomNumber = 1;
    public int numberRolled = 0;

    private bool diceLocked = false;

    private void Start()
    {
        diceRoll = new DiceRollAsync();
    }

    public async void DiceWasClicked()
    {
        if (!diceLocked)
        {
            ChangeDiceLockState();
            if (isRandom)
            {
                numberRolled = await RollTheDice();
                InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(numberRolled);
            }
            else
            {
                InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(nonRandomNumber);
            }
        }
        else Debug.Log("Sorry, the dice is locked");
    }

    public async Task<int> RollTheDice()
    {
        return await diceRoll.RollDiceTheDiceAnim();
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