using System;
using UnityEngine;

public class PlayerMovement : Player
{
    private MovementHandler movementHandler;

    public FieldAltPoint altFieldOn;
    [SerializeField]
    public Vector3 positionToTravelTo;

    public float rotationSpeed = 30f;

    [SerializeField]
    public float movementSpeed = 15f;

    [SerializeField]
    public int spacesToMove = 0;

    private FieldEffectHandler _fieldEffectHandler;

    private void Start()
    {
        movementHandler  = InstanceManager.Instance.Get<MovementHandler>();
        _fieldEffectHandler = InstanceManager.Instance.Get<FieldEffectHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NextField"))
        {
            other.tag = "Untagged";
            if (movementHandler.moveForward)
                movementHandler.MoveToNextField(gameObject);
            else movementHandler.MoveToPreviousField(gameObject);
        }
        else if (other.CompareTag("LastField"))
        {
            other.tag = "Untagged";
            _fieldEffectHandler.TriggerFieldEffects(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        var fieldTransform = currentPlayerField.transform;
        Vector3 targetPosition = fieldTransform.position
                                 + (Vector3.up * 0.5f)
                                 + (fieldTransform.forward*50f);
        Lerping.LerpObjectRotationToPosition(targetPosition, gameObject, rotationSpeed);
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo + (Vector3.up * 0.5f), movementSpeed * Time.deltaTime);
    }
}