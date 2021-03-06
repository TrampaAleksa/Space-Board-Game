﻿using System;
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
    }

    public T AddInstance<T>(T instance)
    {
        gameObject.AddComponent(instance.GetType());
        // instancesDictionary[typeof(T)] = instance;
        return instance;
    }

    public T Get<T>() where T : MonoBehaviour
    {
        T foundComponent = GetComponentInChildren<T>();
        if (foundComponent == null)
        {
            foundComponent = gameObject.AddComponent<T>();
        }
        return foundComponent;
    }
}