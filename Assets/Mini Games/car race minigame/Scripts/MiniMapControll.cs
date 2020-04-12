using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControll : MonoBehaviour
{
    Vector3 pos;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        offset=new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
        pos=new Vector3(0,0,0);
        for(int i=0;i<GameManager.Instance.playersGenericObjectArray.ArrayLength();i++)
        {
            pos+=GameManager.Instance.playersGenericObjectArray.MemberWithIndex(i).transform.position+offset;
        }
        gameObject.transform.position=pos/GameManager.Instance.playersGenericObjectArray.ArrayLength();
    }
}
