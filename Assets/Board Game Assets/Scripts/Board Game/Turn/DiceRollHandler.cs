using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    private DiceRollAsync diceRoll;
    private TooltipHandler _tooltipHandler;
    private MovementHandler _movementHandler;
    
    public bool isRandom = true;
    public int numberRolled = 1;
    private bool diceLocked = false;
 

    private void Start()
    {
        diceRoll = new DiceRollAsync();
        _tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        _movementHandler = InstanceManager.Instance.Get<MovementHandler>();
    }

    public async void DiceWasClicked()
    {
        if (diceLocked)
        {
            _tooltipHandler.ShowInfoTooltip("Sorry, the dice is locked");
            return;
        }
        
        ChangeDiceLockState();
        
        if(isRandom)
        {
            numberRolled = await RollTheDice();
        }
        _movementHandler.MoveCurrentPlayer(numberRolled);
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