using UnityEngine;

namespace Board_Game_Assets.Scripts.Board_Game.Tooltip.Activity_History.Activities
{
    public class ATPlayerLockedTurnSkip : ActivityTooltipBuilder
    {
        public ATPlayerLockedTurnSkip(GameObject player) : base(player)
        {
            BuildActivityTooltip();
        }

        public sealed override void BuildActivityTooltip()
        {
            tooltipMessage += player1Name;
            tooltipMessage += " Skipped their turn due to broken engines.";
        }
    }
}