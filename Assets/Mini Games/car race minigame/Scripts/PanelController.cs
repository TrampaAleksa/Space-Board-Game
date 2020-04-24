using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text playerNameText;
    public Text localRankText;
    public Text playerSpeedText;
    void Awake()
    {
        Text[] tmp=gameObject.GetComponentsInChildren<Text>();
        for(int i=0;i<tmp.Length;i++){
          if(tmp[i].tag=="PlayerName")
            playerNameText=tmp[i];
          else if(tmp[i].tag=="localRank")
            localRankText=tmp[i];
          else if(tmp[i].tag=="PlayerSpeed")
            playerSpeedText=tmp[i];
        } 
    }
}
