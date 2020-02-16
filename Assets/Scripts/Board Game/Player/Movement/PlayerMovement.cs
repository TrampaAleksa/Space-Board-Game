using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    private MovementHandler movementHandler;
    [SerializeField]
    public Vector3 positionToTravelTo;
    [SerializeField]
    public float movementSpeed = 15f;
    [SerializeField]
    public int spacesToMove = 0;

    private void OnTriggerEnter(Collider other)
    {
        movementHandler = InstanceManager.Instance.Get<MovementHandler>();
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            movementHandler.MoveToNextField(gameObject); 
        }
        else if(other.tag == "LastField")
        {
            other.tag = "Untagged";
            FieldEffect[] effects = currentPlayerField.GetComponents<FieldEffect>();
            foreach (var effect in effects) effect.TriggerEffect();
        }
    }
    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo, 15f * Time.deltaTime);
    }

}
