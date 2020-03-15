using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInit : IInitialize
{
    private GenericObjectArray fields;

    public FieldInit(GenericObjectArray fields)
    {
        fields.gameObjects = GameObject.FindGameObjectsWithTag("Field");
        this.fields = fields;
    }

    public IInitialize Initialize()
    {
        int i = 0;
        foreach (var field in fields.gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            Vector3 _lookDirection = fields.MemberWithIndex(i + 1).transform.position - field.transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            field.transform.rotation = Quaternion.Lerp(field.transform.rotation, _rot, 1);
            i++;
        }
        return this;
    }
}