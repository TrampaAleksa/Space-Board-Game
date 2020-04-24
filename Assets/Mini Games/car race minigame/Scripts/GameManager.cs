using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<PanelController> panels;
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
            cameraGenericObjectArray.MemberWithIndex(i).GetComponent<CameraFollowController>().objectToFollow=playersGenericObjectArray;
            playersGenericObjectArray.MemberWithIndex(i).GetComponent<PlayerController>().pathCreator=GameObject.FindWithTag("Field").GetComponent<PathCreator>();
            playersGenericObjectArray.MemberWithIndex(i).GetComponent<PlayerController>().panel=panels[i];
        }
    }
    public void TypeName(int i)
    {
        panels[i].playerNameText.text=ReturnName(i);
        panels[i].localRankText.text="--/04";
    }
    public void SetPosition(int i)
    {
        panels[i].localRankText.text="0"+(playersGenericObjectArray.MemberWithIndex(i).GetComponent<PlayerController>().ReturnIndex()+1)+"/04";
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
        else SceneManager.LoadScene(6);
    }
}