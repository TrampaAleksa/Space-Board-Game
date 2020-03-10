using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{

    public Rigidbody2D player1;
    public Rigidbody2D player2;
    public Rigidbody2D player3;
    public Rigidbody2D player4;

    public GameObject player1GO;
    public GameObject player2GO;
    public GameObject player3GO;
    public GameObject player4GO;

    public float playerSpeed = 10f;

    Vector2 movement1;
    Vector2 movement2;
    Vector2 movement3;
    Vector2 movement4;

    Vector2  mousePos;

    public Camera cam;


    void Awake()
    {
        player1GO = GameObject.FindGameObjectWithTag("Player 1");
        player1 = player1GO.GetComponent<Rigidbody2D>();

        player2GO = GameObject.FindGameObjectWithTag("Player 2");
        player2 = player2GO.GetComponent<Rigidbody2D>();

        player3GO = GameObject.FindGameObjectWithTag("Player 3");
        player3 = player3GO.GetComponent<Rigidbody2D>();

        player4GO = GameObject.FindGameObjectWithTag("Player 4");
        player4 = player4GO.GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        handlePlayerAxis();
        mousePos=cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        handleInput();

        Vector2 lookDir = mousePos - player1.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        player1.rotation = angle;
    }

    public void handleInput()
    {
        if (player1 != null && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            player1.MovePosition(player1.position + movement1 * Time.fixedDeltaTime * playerSpeed);
            print("1");
        }
        if (player2 != null && (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")))
        {
            player2.MovePosition(player2.position + movement2 * Time.fixedDeltaTime * playerSpeed);
            print("2");
        }
        if (player3 != null && (Input.GetKey("u") || Input.GetKey("h") || Input.GetKey("j") || Input.GetKey("k")))
        {
            player3.MovePosition(player3.position + movement3 * Time.fixedDeltaTime * playerSpeed);
            print("3");
        }
        if (player4 != null && (Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4")))
        {
            player4.MovePosition(player4.position + movement4 * Time.fixedDeltaTime * playerSpeed);
            print("4");
        }

    }

    public void handlePlayerAxis()
    {
        movement1.x = Input.GetAxisRaw("Horizontal1");
        movement1.y = Input.GetAxisRaw("Vertical1");

        movement2.x = Input.GetAxisRaw("Horizontal2");
        movement2.y = Input.GetAxisRaw("Vertical2");

        movement3.x = Input.GetAxisRaw("Horizontal3");
        movement3.y = Input.GetAxisRaw("Vertical3");

        movement4.x = Input.GetAxisRaw("Horizontal4");
        movement4.y = Input.GetAxisRaw("Vertical4");

    }






}
