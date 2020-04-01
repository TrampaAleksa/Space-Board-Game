using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsHandler : MonoBehaviour
{
    public static LoopsHandler Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }
    public void Loop(float timeBetweenLoops, Func<bool> loopFunction)
    {
        StartCoroutine(LoopEnum(timeBetweenLoops, loopFunction));
    }

    private IEnumerator LoopEnum(float timeBetweenLoops, Func<bool> loopFunction) 
    {
            yield return new WaitForSeconds(timeBetweenLoops);
            if(loopFunction())
                yield return StartCoroutine(LoopEnum(timeBetweenLoops, loopFunction));

            yield break;
    }

 

}
