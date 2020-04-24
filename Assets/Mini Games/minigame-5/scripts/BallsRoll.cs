using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsRoll : MonoBehaviour
{
    public Rigidbody player1;
    public Rigidbody player2;
    public Rigidbody player3;
    public Rigidbody player4;

    public GameObject player1GO;
    public GameObject player2GO;
    public GameObject player3GO;
    public GameObject player4GO;

    Vector3 movement1;
    Vector3 movement2;
    Vector3 movement3;
    Vector3 movement4;

    public float playerSpeed=1f;

    void Start()
    {
        player1GO = GameObject.FindGameObjectWithTag("Player 1");
        player1 = player1GO.GetComponent<Rigidbody>();

        player2GO = GameObject.FindGameObjectWithTag("Player 2");
        player2 = player2GO.GetComponent<Rigidbody>();

        player3GO = GameObject.FindGameObjectWithTag("Player 3");
        player3 = player3GO.GetComponent<Rigidbody>();

        player4GO = GameObject.FindGameObjectWithTag("Player 4");
        player4 = player4GO.GetComponent<Rigidbody>();
    }


    void Update()
    {
        handlePlayerAxis();
    }

    void FixedUpdate()
    {
        handleMovement();
    }

        void handleMovement()
    {
        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            player1.AddForce(movement1*playerSpeed);
        }
        if ((Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")))
        {
            player2.AddForce(movement2* playerSpeed);
        }
        if ((Input.GetKey("u") || Input.GetKey("h") || Input.GetKey("j") || Input.GetKey("k")))
        {
            player3.AddForce(movement3* playerSpeed);
        }
        if ((Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4")))
        {
            player4.AddForce(movement4* playerSpeed);
        }
    }


    public void handlePlayerAxis()
    {
        movement1.x = Input.GetAxisRaw("Horizontal1");
        movement1.z = Input.GetAxisRaw("Vertical1");

        movement2.x = Input.GetAxisRaw("Horizontal2");
        movement2.z = Input.GetAxisRaw("Vertical2");

        movement3.x = Input.GetAxisRaw("Horizontal3");
        movement3.z = Input.GetAxisRaw("Vertical3");

        movement4.x = Input.GetAxisRaw("Horizontal4");
        movement4.z = Input.GetAxisRaw("Vertical4");

    }

}

