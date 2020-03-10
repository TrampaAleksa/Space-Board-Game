using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    private Rigidbody player1;
    private Rigidbody player2;
    private Rigidbody player3;
    private Rigidbody player4;

    private GameObject player1GO;
    private GameObject player2GO;
    private GameObject player3GO;
    private GameObject player4GO;
    //resiti duplu inicijalizaciju

    public float playerSpeed = 10f;

    //ako gledam odozgo poeram po x i z osi

    Vector3 movement1;
    Vector3 movement2;
    Vector3 movement3;
    Vector3 movement4;

    void Awake()
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

    void Start()
    {
        //inicijalizovati igraca, ne preko public
    }

    void Update()
    {
        handlePlayerAxis();
    }

    void FixedUpdate()
    {
        handleInput();
    }

    public void handleInput()
    {
        if (player1 != null && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            player1.MovePosition(player1.position + movement1 * Time.deltaTime * playerSpeed);
        }
        if (player2 != null && (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")))
        {
            player2.MovePosition(player2.position + movement2 * Time.deltaTime * playerSpeed);
        }
        if (player3 != null && (Input.GetKey("u") || Input.GetKey("h") || Input.GetKey("j") || Input.GetKey("k")))
        {
            player3.MovePosition(player3.position + movement3 * Time.deltaTime * playerSpeed);
        }
        if (player4 != null && (Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4")))
        {
            player4.MovePosition(player4.position + movement4 * Time.deltaTime * playerSpeed);
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
