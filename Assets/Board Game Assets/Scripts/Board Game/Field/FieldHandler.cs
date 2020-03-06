using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldHandler : GenericObjectArray, IBoardState
{
    private FieldMovementImpl fieldMovement;

    private void Awake()
    {
        InitializeFields();
        fieldMovement = new FieldMovementImpl();
    }

    public void SetCurrentField(Field fieldToSetTo, GameObject player)
    {
        fieldMovement.SetCurrentField(fieldToSetTo, player);
    }

    public void TeleportPlayerToField(GameObject player, Field field)
    {
        fieldMovement.TeleportPlayerToField(player, field);
    }

    public void SwapTwoPlayers(PlayerMovement playerMovement1, PlayerMovement playerMovement2)
    {
        fieldMovement.SwapTwoPlayers(playerMovement1, playerMovement2);
    }

    public int DistanceBetweenTwoFields(Field field1, Field field2)
    {
        //Note -- If the player tries to teleport ahead of the finish line or before the finish line print
        //a message saying that he can't do that (the difference between the last index and first index is very big so he
        // wont be able to teleport even if he wanted to).
        return Mathf.Abs(field1.IndexInPath - field2.IndexInPath);
    }

    public Dictionary<Type, string> tooltipMessagesDictionary;

    public void InitializeFields()
    {
        tooltipMessagesDictionary = new Dictionary<Type, string>();
        AddMessagesToDictionary(tooltipMessagesDictionary);
        gameObjects = GameObject.FindGameObjectsWithTag("Field");
        int i = 0;
        foreach (var field in gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            Vector3 _lookDirection = MemberWithIndex(i + 1).transform.position - field.transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            field.transform.rotation = Quaternion.Lerp(field.transform.rotation, _rot, 1);
            i++;
        }
    }

    private void AddMessagesToDictionary(Dictionary<Type, string> tooltipMessagesDictionary)
    {
        for (int i = 0; i < FieldInfoMessages.fieldGameObjectNames.Length; i++)
        {
            tooltipMessagesDictionary.Add
                (FieldInfoMessages.fieldGameObjectNames[i],
                FieldInfoMessages.fieldInfoMessages[i]);
            print("added type of " + FieldInfoMessages.fieldGameObjectNames[i] + "with the message: " + FieldInfoMessages.fieldInfoMessages[i]);
        }
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int index = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].pathIndex
                = player.GetComponent<PlayerMovement>().currentPlayerField.IndexInPath;
            print("Saved players position index: " + index);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int index = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].pathIndex;
            MemberWithIndex(index).GetComponent<Field>().AddPlayerToField(player);
            i++;
        }
    }
}