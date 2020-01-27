using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FieldPath path;
    private GameObject currentField;
    private Vector3 positionToTravelTo;
    private int currentPathIndex;
    private FieldAltPoints currentFieldAltPoints;
    public float movementSpeed = 15f;

    private bool shouldMove = false;
    private int spacesToMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPathIndex = 0;
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
        currentField = path.fields[0];
        positionToTravelTo = currentField.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleFieldCollison();
    }

    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo, 15f * Time.deltaTime);
    }

    public void MoveNFields(int n)
    {
        spacesToMove = n;
        shouldMove = true;
        moveToNextField();
    }

    public void moveToNextField()
    {
        spacesToMove--;
        //initial field
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();
        currentFieldAltPoints.playersOnField--;

        //next field
        currentPathIndex = (currentPathIndex+1)%(path.fields.Length);
        currentField = path.fields[currentPathIndex];
        currentFieldAltPoints = currentField.GetComponent<FieldAltPoints>();
        currentFieldAltPoints.playersOnField++;
        positionToTravelTo = currentFieldAltPoints.altPoints[currentFieldAltPoints.playersOnField - 1].transform.position;


    }

    public void HandleFieldCollison()
    {
        shouldMove = spacesToMove > 0;
        if (shouldMove)
        {
            moveToNextField();
        }
        else
        {
            //TODO - The trigger shouldn't be dependant of the "should move" boolean value. Set the trigger 
            //so that it triggers based on a tag.
                currentField.GetComponent<FieldEffect>().TriggerEffect();
        }
    }
}
