using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInitPath : IInitialize
{
    private PathCreator pathCreator;

    private GenericObjectArray fields;

    public FieldInitPath(GenericObjectArray fields)
    {
        fields.gameObjects = GameObject.FindGameObjectsWithTag("Field");
        this.pathCreator = GameObject.Find("path").GetComponent<PathCreator>();
        this.fields = fields;
    }

    public IInitialize Initialize()
    {
        float interval = pathCreator.path.length / fields.ArrayLength();
        float tmp = interval;
        int i = 0;
        foreach (var field in fields.gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);

            field.transform.position = pathCreator.path.GetPointAtDistance(interval += tmp);

            Vector3 _lookDirection = pathCreator.path.GetPointAtDistance(interval + tmp) - field.transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            field.transform.rotation = Quaternion.Lerp(field.transform.rotation, _rot, 1);
            i++;
        }
        GameObject.Destroy(pathCreator.gameObject);
        return this;
    }
}