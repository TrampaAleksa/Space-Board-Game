using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CheckPoint : MonoBehaviour
{
    public PathCreator pathCreator;
    public static int numberOfCheckpoint=8;
    public static float distance;
    public int numberOfPlayerCross=0;
    public static int checkpointIndex=0;
    public int checkpoint=0;
    public static CheckPoint Instance;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        numberOfPlayerCross=0;
        pathCreator=GameObject.FindWithTag("Field").GetComponent<PathCreator>();
        checkpointIndex++;
        checkpoint=checkpointIndex;
        if(checkpointIndex==1)
            distance=pathCreator.path.length/numberOfCheckpoint;
        gameObject.transform.position=pathCreator.path.GetPointAtDistance(distance*checkpointIndex)+new Vector3(0,1,0);
        gameObject.transform.localRotation=pathCreator.path.GetRotationAtDistance(distance*checkpointIndex);
        gameObject.transform.localEulerAngles= new Vector3 (transform.localEulerAngles.x,transform.localEulerAngles.y, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>().lastIndexCheckpointPass!=checkpoint)
        {
            numberOfPlayerCross++;
            other.GetComponent<PlayerController>().UpdateLocalRank(numberOfPlayerCross,checkpoint);
            other.GetComponent<PlayerController>().lastIndexCheckpointPass=checkpoint;
        }
        if(numberOfPlayerCross==1)
            UpdatePosition();
        else if(numberOfPlayerCross==4)
            gameObject.SetActive(false);
    }
    private void UpdatePosition()
    {
        if(checkpointIndex<=numberOfCheckpoint)
        {
            Instantiate(gameObject);
        }
    }
}