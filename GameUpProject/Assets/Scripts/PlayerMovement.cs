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
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPathIndex = 0;
        path = GameObject.Find("Field Container").GetComponent<FieldPath>();
    }

    private void Update()
    {
        //TODO -- Messy code, needs some cleanup later
        if (spacesToMove > 0)
        {
            if (shouldMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, path.fields[currentPathIndex].transform.position, 15f * Time.deltaTime);
                if (transform.position == path.fields[currentPathIndex].transform.position)
                {
                    shouldMove = false;
                }
            }
            else
            {
                if (spacesToMove > 0)
                {
                    print(++i);
                    moveToNextField();
                    shouldMove = true;
                }
                spacesToMove--;
            }
        }
   
    }

    public void MoveNFields(int n)
    {
        spacesToMove = n;
        shouldMove = true;
    }

    public void moveToNextField()
    {
        currentPathIndex= (currentPathIndex+1)%(path.fields.Length);
    }
}
