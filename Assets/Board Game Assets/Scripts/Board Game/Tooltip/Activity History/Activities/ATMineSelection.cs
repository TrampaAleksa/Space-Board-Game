using UnityEngine;

namespace Board_Game_Assets.Scripts.Board_Game.Tooltip.Activity_History.Activities
{
    public class ATMineSelection : ActivityTooltipBuilder
    {
        public ATMineSelection(GameObject player) : base(player)
        {
            BuildActivityTooltip();
        }

        public sealed override void BuildActivityTooltip()
        {
            tooltipMessage += player1Name;
            tooltipMessage += " is selecting field for mine.";
        }
    }
}