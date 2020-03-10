using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInfoDictionaryHandler : MonoBehaviour
{
    private Dictionary<Type, string> tooltipMessagesDictionary;

    public Dictionary<Type, string> TooltipMessagesDictionary { get => tooltipMessagesDictionary; set => tooltipMessagesDictionary = value; }

    public void InitializeDictionary()
    {
        TooltipMessagesDictionary = new Dictionary<Type, string>();
        AddMessagesToDictionary(TooltipMessagesDictionary);
    }

    public void AddMessagesToDictionary(Dictionary<Type, string> tooltipMessagesDictionary)
    {
        for (int i = 0; i < FieldInfoMessages.fieldGameObjectTypes.Length; i++)
        {
            tooltipMessagesDictionary.Add
                (FieldInfoMessages.fieldGameObjectTypes[i],
                FieldInfoMessages.fieldInfoMessages[i]);
            print("added type of " + FieldInfoMessages.fieldGameObjectTypes[i] + "with the message: " + FieldInfoMessages.fieldInfoMessages[i]);
        }
    }
}