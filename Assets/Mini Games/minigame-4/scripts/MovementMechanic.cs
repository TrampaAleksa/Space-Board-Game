using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanic : MonoBehaviour
{
    [SerializeField]
    float rcsThrust = 100f;  //setuje default vrednsot na 100f(pocetnu vrednsot)
    [SerializeField]
    float mainThrust = 200f;
    

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    Rigidbody rigidBody1;
    Rigidbody rigidBody2;
    Rigidbody rigidBody3;
    Rigidbody rigidBody4;
   

    bool isTransitioning = false;
    bool collisionsDisabled = false;

    public ParticleSystem JetParticles1;
    public ParticleSystem JetParticles2;
    public ParticleSystem JetParticles3;
    public ParticleSystem JetParticles4;

    // Use this for initialization
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        rigidBody1 = player1.GetComponent<Rigidbody>();

        player2 = GameObject.FindGameObjectWithTag("Player 2");
        rigidBody2 = player2.GetComponent<Rigidbody>();

        player3 = GameObject.FindGameObjectWithTag("Player 3");
        rigidBody3 = player3.GetComponent<Rigidbody>();

        player4 = GameObject.FindGameObjectWithTag("Player 4");
        rigidBody4 = player4.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RespondToThrustInput();
        RespondToThrustInput1();
        RespondToThrustInput2();
        RespondToThrustInput3();

        RespondToRotateInput();

    }


    private void RespondToThrustInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
            JetParticles1.Play();
        }else
        {
            JetParticles1.Stop();
        }
    }

    private void RespondToThrustInput1()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ApplyThrust1();
            JetParticles2.Play();
        }
        else
        {
            JetParticles2.Stop();
        }
    }
    private void RespondToThrustInput2()
    {

        if (Input.GetKey(KeyCode.U))
        {
            ApplyThrust2();
            JetParticles3.Play();
        }
        else
        {
            JetParticles3.Stop();
        }
    }
    private void RespondToThrustInput3()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            ApplyThrust3();
            JetParticles4.Play();
        }
        else
        {
            JetParticles4.Stop();
        }
    }


    private void ApplyThrust()
    {
        rigidBody1.AddRelativeForce(Vector3.up * mainThrust);
    }
    private void ApplyThrust1()
    {
        rigidBody2.AddRelativeForce(Vector3.up * mainThrust);
    }
    private void ApplyThrust2()
    {
        rigidBody3.AddRelativeForce(Vector3.up * mainThrust);
    }
    private void ApplyThrust3()
    {
        rigidBody4.AddRelativeForce(Vector3.up * mainThrust);
    }

    private void RespondToRotateInput()
    {
        //rigidBody.freezeRotation = true;
        //rigidBody.freezeRotation = false;

        rigidBody1.angularVelocity = Vector3.zero; //remove rotation due to physics  
        rigidBody2.angularVelocity = Vector3.zero;
        rigidBody3.angularVelocity = Vector3.zero;
        rigidBody4.angularVelocity = Vector3.zero;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            player1.transform.Rotate(Vector3.forward * rotationThisFrame);
           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player1.transform.Rotate(-Vector3.forward * rotationThisFrame);
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2.transform.Rotate(Vector3.forward * rotationThisFrame);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player2.transform.Rotate(-Vector3.forward * rotationThisFrame);
          
        }

        if (Input.GetKey(KeyCode.H))
        {
            player3.transform.Rotate(Vector3.forward * rotationThisFrame);
           
        }
        else if (Input.GetKey(KeyCode.K))
        {
            player3.transform.Rotate(-Vector3.forward * rotationThisFrame);
           
        }

        if (Input.GetKey(KeyCode.M))
        {
            player4.transform.Rotate(Vector3.forward * rotationThisFrame);
           
        }
        else if (Input.GetKey(KeyCode.B))
        {
            player4.transform.Rotate(-Vector3.forward * rotationThisFrame);
         
        }




    }
}
