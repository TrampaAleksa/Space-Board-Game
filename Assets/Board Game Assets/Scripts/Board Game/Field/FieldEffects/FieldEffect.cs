using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldEffect : MonoBehaviour
{
    [SerializeField]
    public PlayersHandler playersHandler;
    public const string TAG_SELECTION = "Selection";
    protected ISelectionEffect selectionEffect;

    private void Start()
    {
        playersHandler = InstanceManager.Instance.Get<PlayersHandler>();
    }
    public abstract void TriggerEffect();
    public abstract void TooltipDisplay();
}
