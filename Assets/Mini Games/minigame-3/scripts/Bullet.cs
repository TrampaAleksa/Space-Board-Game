using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

     void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player 2" || collision.gameObject.tag == "Player 3" || collision.gameObject.tag == "Player 4")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag!="Player 1" && collision.gameObject.tag != "Player 2" && collision.gameObject.tag != "Player 3" && collision.gameObject.tag != "Player 4" )
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
        }
        
    }
}
