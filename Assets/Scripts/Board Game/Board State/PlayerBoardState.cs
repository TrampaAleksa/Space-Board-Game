using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerBoardState", menuName ="BoardStateSO")]
public class PlayerBoardState : ScriptableObject
{
    public float fuel;
    public float hull;
    public int pathIndex;
    public int checkpointIndex;
    public int rank;
    public int turnsToSkip;
    
}
