﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce3 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player 1" || collision.gameObject.tag == "Player 2" || collision.gameObject.tag == "Player 4")
        {
            print("takle se 3");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*4f, ForceMode.Impulse);
            this.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward*4f, ForceMode.Impulse);
        }
    }
}
