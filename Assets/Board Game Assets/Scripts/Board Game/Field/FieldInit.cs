using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInit : IInitialize
{
    private PathCreator pathCreator;

    private GenericObjectArray fields;
    private float interval;

    public FieldInit(GenericObjectArray fields)
    {
        this.pathCreator = GameObject.Find("path").GetComponent<PathCreator>();
        this.fields = fields;
        Debug.Log(pathCreator.path.length);
        this.interval = pathCreator.path.length / 54;
        Debug.Log(this.interval);

    }

    public IInitialize Initialize()
    {
        fields.gameObjects = GameObject.FindGameObjectsWithTag("Field");
        float tmp = interval;
        int i = 0;
        foreach (var field in fields.gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            field.transform.position = pathCreator.path.GetPointAtDistance(interval += tmp);
            Vector3 _lookDirection = fields.MemberWithIndex(i + 1).transform.position - field.transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            field.transform.rotation = Quaternion.Lerp(field.transform.rotation, _rot, 1);
            Debug.Log(field.transform.position);
            i++;
        }
        return this;
    }
}