using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectInit : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("field effect init");
        FieldEffectHandler fieldEffectHandler = InstanceManager.Instance.Get<FieldEffectHandler>();

        foreach (var field in InstanceManager.Instance.Get<FieldHandler>().gameObjects)
        {
            if (field.GetComponent<FieldEffect>() != null)
            {
                Debug.Log("Field effect found");
                foreach (var component in field.GetComponents<FieldEffect>())
                {
                    fieldEffectHandler.AddEffectToField(field, component);
                    fieldEffectHandler.AddEffectFinishedEventToField(field, component);
                }
            }
        }
    }

    public void InitEffectsForField(GameObject field)
    {
    }
}