using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FieldPath path;
    private int currentPathIndex;

    public float movementSpeed = 15f;

    private bool shouldMove = false;
    private int spacesToMove = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPathIndex = 0;
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleFieldCollison();
    }

    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, path.fields[currentPathIndex].transform.position, 15f * Time.deltaTime);
    }

    public void MoveNFields(int n)
    {
        spacesToMove = n;
        shouldMove = true;
        moveToNextField();
    }

    public void moveToNextField()
    {
        currentPathIndex= (currentPathIndex+1)%(path.fields.Length);
    }

    public void HandleFieldCollison()
    {
        spacesToMove--;
        shouldMove = spacesToMove > 0;
        if (shouldMove)
        {
            moveToNextField();
        }
        else
        {
            print("Final field");
        }
    }
}
