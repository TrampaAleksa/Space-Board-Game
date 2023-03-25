using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFieldSelectionEvent : MonoBehaviour, ISelectionEffect
{
    private GameObject _mineObj;

    public void ConfirmedSelection()
    {
        GameObject selectedField = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField();
        if (selectedField.GetComponent<EmptyField>() == null)
        {
            Debug.Log("Mine can only be placed on empty field");
            return;
        }

        var mineObj = Instantiate(_mineObj, selectedField.transform, false);
        mineObj.transform.localPosition = Vector3.zero;
        
        var mineEffect = selectedField.AddComponent<Mine>();
        mineEffect.mineObj = mineObj;
        
        InstanceManager.Instance.Get<FieldEffectHandler>()
            .AddEffectToField(selectedField, mineEffect);
        
        new ATMinePlacement(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).DisplayAT();
        
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
        //Mine placed sound
    }




    public void SetMineObj(GameObject mineObj) => _mineObj = mineObj;

}