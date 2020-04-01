using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        for(int i=0;i<cameraGenericObjectArray.ArrayLength();i++)
        {
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