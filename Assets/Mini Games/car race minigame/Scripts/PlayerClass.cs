using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerClass
{
    private int element;
    private string name;

    public PlayerClass(int element, string name)
    {
        this.element = element;
        this.name = name;

    }
    public int Element
    {
        get { return element; }
        set { element=value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
