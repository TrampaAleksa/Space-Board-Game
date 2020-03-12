using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInit : IInitialize
{
    public PathCreator pathCreator;

    private GenericObjectArray fields;
    private int interval;

    public FieldInit(GenericObjectArray fields)
    {
        this.fields = fields;
        Debug.Log(pathCreator.path.length);
        this.interval = (int)pathCreator.path.length/50;

    }

    public IInitialize Initialize()
    {
        fields.gameObjects = GameObject.FindGameObjectsWithTag("Field");
        int i = 0;
        foreach (var field in fields.gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            Vector3 _lookDirection = fields.MemberWithIndex(i + 1).transform.position - field.transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            field.transform.rotation = Quaternion.Lerp(field.transform.rotation, _rot, 1);
            field.transform.position = pathCreator.path.GetPoint(interval*i);
            Debug.Log(field.transform.position);
            i++;
        }
        return this;
    }
}