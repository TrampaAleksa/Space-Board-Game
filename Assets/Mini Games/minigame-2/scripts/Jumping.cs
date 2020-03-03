using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Rigidbody player1RB;
    public Rigidbody player2RB;
    public Rigidbody player3RB;
    public Rigidbody player4RB;

    public float jumpForce = 1f;

    private bool canJump1;
    private bool canJump2;
    private bool canJump3;
    private bool canJump4;

   // public CanJump CanJumpScript;

    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player1RB = player1.GetComponent<Rigidbody>();

        player2 = GameObject.FindGameObjectWithTag("Player 2");
        player2RB = player2.GetComponent<Rigidbody>();

        player3 = GameObject.FindGameObjectWithTag("Player 3");
        player3RB = player3.GetComponent<Rigidbody>();

        player4 = GameObject.FindGameObjectWithTag("Player 4");
        player4RB = player4.GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        handleJumping();
    }

    void Update()
    {
        jump();
    }

    public void jump()
    {
        if (Input.GetKeyDown("space") && CanJump1.canJump==true)
        {
            canJump1 = true;
        }
        if (Input.GetKeyDown("a") && CanJump2.canJump==true)
        {
            canJump2 = true;
        }
        if (Input.GetKeyDown("s") && CanJump3.canJump == true)
        {
            canJump3 = true;
        }
        if (Input.GetKeyDown("d") && CanJump4.canJump == true)
        {
            canJump4 = true;
        }
    }

    public void handleJumping()
    {
        if (canJump1)
        {
            canJump1 = false;
            player1RB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if (canJump2)
        {
            canJump2 = false;
            player2RB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if (canJump3)
        {
            canJump3 = false;
            player3RB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if (canJump4)
        {
            canJump4 = false;
            player4RB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}

