using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstancesAdder
{
    static internal void AddInstances(InstanceManager manager)
    {
        //Any instance you want to add goes here
        InstanceManager.Instance.AddInstance<FieldHandler>(manager.gameObject.GetComponent<FieldHandler>());
        InstanceManager.Instance.AddInstance<PlayersHandler>(manager.gameObject.GetComponent<PlayersHandler>());
        InstanceManager.Instance.AddInstance<DiceRollHandler>(manager.gameObject.GetComponent<DiceRollHandler>());
        InstanceManager.Instance.AddInstance<MovementHandler>(manager.gameObject.GetComponent<MovementHandler>());

    }

    public static void TestInstances()
    {
        //if you want to see if the instance has successfully been added
    }
}
