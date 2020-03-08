using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentHendler : MonoBehaviour
{
    public static AddComponentHendler Instance;
    public string[] nameOfWheelColliderObject=new string[] {"WC_FRONTLEFT","WC_FRONTRIGHT","WC_REARLEFT","WC_REARRIGHT"};
    void Awake()
    {
        Instance=this;
    }
    /*
    public T[] AddAnyComponent<T>(T[] param,string[] names)
    {
        int j=0;
        T[] newArray=param;
        for(int i=0;i<newArray.Length;i++)
        {
            if(newArray[i].name==names[i]){
                param[j]=newArray[i];
                j++;
            }
                
        }
        return param;
    }*/
}
