﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    private PlayerFieldMovement movementHandler;
    [SerializeField]
    public Vector3 positionToTravelTo;
    [SerializeField]
    public float movementSpeed = 15f;
    [SerializeField]
    public int spacesToMove = 0;

    void Start()
    {
        movementHandler = InstanceManager.Instance.Get<PlayerFieldMovement>();
        path = InstanceManager.Instance.Get<FieldHandler>();
        path.SetupPlayerFieldOnLoad(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            movementHandler.MoveToNextField(gameObject, currentPlayerField.GetComponent<Field>().IndexInPath);
        }
        else if(other.tag == "LastField")
        {
            other.tag = "Untagged";
            currentPlayerField.GetComponent<FieldEffect>().TriggerEffect();
        }
    }
    private void FixedUpdate()
    {  
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo, 15f * Time.deltaTime);
    }

}
