using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance;
    private Dictionary<Type, object> instancesDictionary;

    private void Awake()
    {
        Instance = this;
        instancesDictionary = new Dictionary<Type, object>();

        AddInstance<Instance1>(gameObject.GetComponent<Instance1>());
        AddInstance<Instance2>(gameObject.GetComponent<Instance2>());
    }

    private void Start()
    {

        print(Get<Instance1>().gameObject.name);
        print(Get<Instance2>().gameObject.name);
    }

    public T AddInstance<T>(T instance)
    {
        instancesDictionary[typeof(T)] = instance;
        return instance;
    }

    public T Get<T>()
    {
        if (IsTypeExists(typeof(T)) == false)
        {
            return default(T);
        }

        return (T)instancesDictionary[typeof(T)];
    }
    public bool IsTypeExists(Type t)
    {
        if (instancesDictionary.ContainsKey(t) == false)
            return false;
        else
            return true;
    }
}
