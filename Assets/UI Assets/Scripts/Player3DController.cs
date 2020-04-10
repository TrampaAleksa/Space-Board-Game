using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour
{
    static List<GameObject> spaceShips= new List<GameObject>();
    public static Player3DController Instance;
    private void Awake() {
        Instance=this;
    }
    private void Start() {
        spaceShips.Add(gameObject);
        gameObject.SetActive(false);
    }
    private void Update() {
        gameObject.transform.Rotate(0,30*Time.deltaTime,0);
    }
    public void ShowSpaceShip()
    {
        for(int i=0;i<spaceShips.Count;i++)
            spaceShips[i].SetActive(true);
    }
    public void DisableSpaceShip()
    {
        for(int i=0;i<spaceShips.Count;i++)
            spaceShips[i].SetActive(false);
    }
}
