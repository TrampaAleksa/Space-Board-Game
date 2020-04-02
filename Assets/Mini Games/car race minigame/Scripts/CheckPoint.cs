using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CheckPoint : MonoBehaviour
{
    public PathCreator pathCreator;
    public int numberOfCheckpoint;
    public float distance;
    public int numberOfPlayerCross=0;
    public int checkpointIndex=0;
    public static CheckPoint Instance;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        pathCreator=GameObject.FindWithTag("Field").GetComponent<PathCreator>();
        distance=pathCreator.path.length/numberOfCheckpoint;
        UpdatePosition();
    }
    void OnTriggerEnter(Collider other)
    {
        numberOfPlayerCross++;
        other.GetComponent<PlayerController>().UpdateLocalRank(numberOfPlayerCross);
        if(numberOfPlayerCross==4)
            UpdatePosition();
    }
    private void UpdatePosition()
    {
        numberOfPlayerCross=0;
        checkpointIndex++;
        gameObject.transform.position=pathCreator.path.GetPointAtDistance(distance*checkpointIndex);
        gameObject.transform.localRotation=pathCreator.path.GetRotationAtDistance(distance*checkpointIndex);
        gameObject.transform.localEulerAngles= new Vector3 (transform.localEulerAngles.x,transform.localEulerAngles.y, 0);
    }
    
}
