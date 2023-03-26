using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Board_Game_Assets.Scripts.Board_Game.Field;
using UnityEngine;

public class MineFieldSelectionEvent : MonoBehaviour, ISelectionEffect
{
    private GameObject _mineObj;

    //TODO - Implement method that swaps one field with another field, much cleaner than combining mine and empty like its done here
    public void ConfirmedSelection()
    {
        GameObject selectedField = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField();

        if (NotValidSelection(selectedField))
            return;
        
        var fieldEffectHandler = InstanceManager.Instance.Get<FieldEffectHandler>();
        var mineEffect = selectedField.AddComponent<Mine>();

        PlantMine(selectedField, mineEffect);
        CombineMineAndEmptyField(fieldEffectHandler, selectedField, mineEffect);

        new ATMinePlacement(
            InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer()
        ).DisplayAT();
        
        fieldEffectHandler.TriggerEffectFinishedEvents(gameObject);
        //Mine placed sound
    }

    private void PlantMine(GameObject selectedField, Mine mineEffect)
    {
        var mineObj = Instantiate(_mineObj, selectedField.transform, false);
        InstanceManager.Instance.Get<FieldHandler>().SetFieldHaloColor(selectedField.gameObject, FieldColor.Red);
        mineEffect.mineObj = mineObj;
    }

    // First triggers Mine Effects then the Empty Field effect(ends turn)
    private static void CombineMineAndEmptyField(FieldEffectHandler fieldEffectHandler, GameObject selectedField, Mine mineEffect)
    {
        fieldEffectHandler.AddEffectToField(selectedField, mineEffect);

        var emptyFieldEffect = selectedField.GetComponent<EmptyField>();
        
        fieldEffectHandler.RemoveEffectFromField(selectedField, emptyFieldEffect);
        fieldEffectHandler.RemoveEffectFinishedEventFromField(selectedField, emptyFieldEffect);

        fieldEffectHandler.AddEffectToField(selectedField, emptyFieldEffect);
        fieldEffectHandler.AddEffectFinishedEventToField(selectedField, emptyFieldEffect);
    }

    
    
    private bool NotValidSelection(GameObject selectedField)
    {
        if (selectedField.GetComponent<EmptyField>() == null)
        {
            Debug.Log("Mine can only be placed on empty field");
            return true;
        }
        if (selectedField.GetComponent<Mine>() != null)
        {
            Debug.Log("A Mine is already placed there!");
            return true;
        }
        if (IsPlayerOnField(selectedField))
        {
            Debug.Log("Can't place mine - Player on field");
            return true;
        }

        return false;
    }

    private bool IsPlayerOnField(GameObject selectedField)
    {
        var selectedFieldIndex = selectedField.GetComponent<Field>().IndexInPath;
        var players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        
        return players.Any(playerObj => playerObj.GetComponent<Player>().currentPlayerField.IndexInPath == selectedFieldIndex);
    }

    public void SetMineObj(GameObject mineObj) => _mineObj = mineObj;

}