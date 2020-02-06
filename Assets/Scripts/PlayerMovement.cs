using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FieldPath path;
    private MovementHandler movementHandler;
    private GameObject currentField;
    [SerializeField]
    public Vector3 positionToTravelTo;
    public int currentPathIndex;
    private FieldAltPoints currentFieldAltPoints;
    public float movementSpeed = 15f;

    [SerializeField]
    public int spacesToMove = 0;


    void Start()
    {
        movementHandler = InstanceManager.Instance.Get<MovementHandler>();
        currentPathIndex = 0;
        path = InstanceManager.Instance.Get<FieldPath>();
        currentField = path.fields[0];
        positionToTravelTo = currentField.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            movementHandler.MoveToNextField(gameObject,currentPathIndex);
        }
        else if(other.tag == "LastField")
        {
            other.tag = "Untagged";
            currentField.GetComponent<FieldEffect>().TriggerEffect();
        }
    }
    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo, 15f * Time.deltaTime);
    }
    public void SetCurrentField(int fieldIndex)
    {
        //update the current field to be without the player
        currentField = path.fields[currentPathIndex];
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();
        currentFieldAltPoints.playersOnField--;

        //get the field you are supposed to move to
        currentPathIndex = fieldIndex;
        currentField = path.fields[fieldIndex];
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();

        //Update the next field to have the player on it
        FieldAltPoints nextFieldAltPoints = currentFieldAltPoints;
        nextFieldAltPoints.playersOnField++;
        positionToTravelTo = nextFieldAltPoints.altPoints[nextFieldAltPoints.playersOnField - 1].transform.position;

    }

}
