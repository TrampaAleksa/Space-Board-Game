using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControll : MonoBehaviour
{
    Vector3 pos;
    Vector3 worldPoseOfPlayer;
    float distance;
    Camera cam;
    public Vector3 bound;
    void Start()
    {
        pos=new Vector3(0,2,0);
        cam=gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        float maxDistance=0;
        pos=new Vector3(0,0,0);
        for(int i=0;i<GameManager.Instance.playersGenericObjectArray.ArrayLength();i++)
        {
            worldPoseOfPlayer=cam.WorldToScreenPoint(GameManager.Instance.playersGenericObjectArray.MemberWithIndex(i).transform.position);
            if(worldPoseOfPlayer.y+20<0 || worldPoseOfPlayer.y+20>480 || worldPoseOfPlayer.y-20<0 || worldPoseOfPlayer.y+20>480 || worldPoseOfPlayer.x-20<0 || worldPoseOfPlayer.x+20>480)
                cam.orthographicSize+=1;
            pos+=GameManager.Instance.playersGenericObjectArray.MemberWithIndex(i).transform.position;
            distance=Vector3.Distance(new Vector3(240,240,0),worldPoseOfPlayer);
            if(distance>maxDistance)
                maxDistance=distance;
        }
        distance=maxDistance;
        gameObject.transform.position=pos/GameManager.Instance.playersGenericObjectArray.ArrayLength();
        if(distance<150)
            cam.orthographicSize-=1;
    }
}