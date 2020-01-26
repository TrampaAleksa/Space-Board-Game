using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FieldPath path;
    private GameObject currentField;
    private int currentPathIndex;

    public float movementSpeed = 15f;

    private bool shouldMove = false;
    private int spacesToMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPathIndex = 0;
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
        currentField = path.fields[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleFieldCollison();
    }

    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, currentField.transform.position, 15f * Time.deltaTime);
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
        currentPathIndex = (currentPathIndex+1)%(path.fields.Length);
        currentField = path.fields[currentPathIndex];
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
            if(currentField.GetComponent<FieldEffect>() != null)
                currentField.GetComponent<FieldEffect>().TriggerEffect();
        }
    }
}
