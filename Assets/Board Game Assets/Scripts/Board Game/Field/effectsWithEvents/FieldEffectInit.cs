using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectInit : MonoBehaviour
{
    private void Start()
    {
        FieldEffectHandler fieldEffectHandler = InstanceManager.Instance.Get<FieldEffectHandler>();

        foreach (var field in InstanceManager.Instance.Get<FieldHandler>().gameObjects)
        {
            if (field.GetComponent<FieldEffect>() != null)
            {
                foreach (var component in field.GetComponents<FieldEffect>())
                {
                    fieldEffectHandler.AddEffectToField(field, component);
                    fieldEffectHandler.AddEffectFinishedEventToField(field, component);
                }
            }
        }
    }
}