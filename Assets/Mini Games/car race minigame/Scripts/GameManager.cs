using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GenericObjectArray countSpeed;
    public GenericObjectArray playerNameText;
    public GenericObjectArray distanceCheckpoint;
    public GenericObjectArray cameraGenericObjectArray;
    public GenericObjectArray playersGenericObjectArray;
    public int count=0;
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        cameraGenericObjectArray =gameObject.AddComponent<GenericObjectArray>();
        playersGenericObjectArray=gameObject.AddComponent<GenericObjectArray>();
        countSpeed=gameObject.AddComponent<GenericObjectArray>();
        playerNameText=gameObject.AddComponent<GenericObjectArray>();
        distanceCheckpoint=gameObject.AddComponent<GenericObjectArray>();
        cameraGenericObjectArray.gameObjects=GameObject.FindGameObjectsWithTag("MainCamera");
        playersGenericObjectArray.gameObjects=GameObject.FindGameObjectsWithTag("Player");
        countSpeed.gameObjects= GameObject.FindGameObjectsWithTag("PlayerSpeed");
        playerNameText.gameObjects= GameObject.FindGameObjectsWithTag("PlayerName");
        distanceCheckpoint.gameObjects= GameObject.FindGameObjectsWithTag("DistanceCheckpoint");
        
        for(int i=0;i<cameraGenericObjectArray.ArrayLength();i++)
        {
            cameraGenericObjectArray.MemberWithIndex(i).GetComponent<CameraFollowController>().objectToFollow=playersGenericObjectArray;
            playersGenericObjectArray.MemberWithIndex(i).GetComponent<PlayerController>().cameraFollowController=cameraGenericObjectArray.MemberWithIndex(i).GetComponent<CameraFollowController>();
            playersGenericObjectArray.MemberWithIndex(i).GetComponent<PlayerController>().pathCreator=GameObject.FindWithTag("Field").GetComponent<PathCreator>();
        }
    }
    public string ReturnName(int number)
    {
        return BoardStateHolder.Instance.playerBoardStates[number].playerName;
    }
    public void PlayerDeath(int index, CameraFollowController camera)
    {
        count++;
        camera.finishGame = true;
        camera.deathOrNot = true;
        BoardStateHolder.Instance.playerBoardStates[index].rank=count;
        if(count!=4)
            camera.ChangeIndex(camera.index);
        else SceneManager.LoadScene(1);
    }
}