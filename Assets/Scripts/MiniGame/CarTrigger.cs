using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigger : MonoBehaviour
{
    Color colorOfPoint;
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points")) 
        {
            other.gameObject.SetActive(false);//gasim poen
            colorOfPoint = other.GetComponent<Renderer>().material.color;//uzimam boju poena
            gameManager.PickUp(colorOfPoint); //pick up (GAmeManager)
        }
        if (other.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
                gameManager.completeAll();
            else gameManager.CompleteLevel();
        }
    }
}