using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectEffect : FieldEffect
{
    public ISelectionEffect selectionEffect;

    public abstract void GenericSelectTrigger();

    public abstract void SelectionInputs();

    public abstract void FinishedSelecting();
}