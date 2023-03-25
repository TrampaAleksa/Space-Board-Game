using System;
using System.Collections.Generic;
using Board_Game_Assets.Scripts.Board_Game.Field;
using UnityEngine;

public class FieldHandler : GenericObjectArray
{
    private FieldMovementImpl fieldMovement;
    [SerializeField]
    private FieldMaterials haloMaterials;
    public const int StartingIndex = 0;
    
    private void Awake()
    {
        new FieldInitPath(this).Initialize();
        fieldMovement = new FieldMovementImpl();
    }

    private void Start()
    {
        InstanceManager.Instance.Get<FieldInfoDictionaryHandler>().InitializeDictionary();
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
    
    public void SetFieldHaloColor(GameObject field, FieldColor color)
    {
        haloMaterials.SetSelectedColor(color);
        var fieldHaloObj = field.transform.Find("Ring").gameObject; // TODO - Extract Method inside field for getting the ring
        haloMaterials.SetFieldColor(fieldHaloObj);
    }

}