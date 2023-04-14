using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour
{
    private void Start() {
        gameObject.SetActive(false);
    }
    private void Update() {
        gameObject.transform.Rotate(0,30*Time.deltaTime,0);
    }
    public void ShowSpaceShip()
    {
        gameObject.SetActive(true);
    }
    public void DisableSpaceShip()
    {
        gameObject.SetActive(false);

    }
}
