using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectInit : MonoBehaviour
{
    private void InitEffectsForField(GameObject field)
    {
        FieldEffectHandler fieldEffectHandler = InstanceManager.Instance.Get<FieldEffectHandler>();

        if (gameObject.GetComponent<IFieldEffect>() != null)
        {
            foreach (var component in gameObject.GetComponents<IFieldEffect>())
            {
                fieldEffectHandler.AddEffectToField(field, component);
                fieldEffectHandler.AddEffectFinishedEventToField(field, component);
            }
        }
    }
}