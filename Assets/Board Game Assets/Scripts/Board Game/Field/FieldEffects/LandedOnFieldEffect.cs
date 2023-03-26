namespace Board_Game_Assets.Scripts.Board_Game.Field.FieldEffects
{
    public class LandedOnFieldEffect : FieldEffect, IGenericFieldEffect
    {
        public string fieldType = "";
        public override void FinishedEffect()
        {
            
        }

        public override void TriggerEffect()
        {
            new ATLandedOnField(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer())
                .SetFieldType(fieldType)
                .DisplayAT();
        }
    }
}