using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump2 : MonoBehaviour
{
    public static bool canJump = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    void Update()
    {
        print(canJump); //radi
    }
}
