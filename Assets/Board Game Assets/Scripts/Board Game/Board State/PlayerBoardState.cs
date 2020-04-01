using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerBoardState", menuName ="BoardStateSO")]
public class PlayerBoardState : ScriptableObject
{
    public float fuel { get; set; }
    public float hull { get; set; }
    public int pathIndex { get; set; }
    public int checkpointIndex { get; set; }
    public int rank { get; set; }
    public int turnsToSkip { get; set; }

    public string playerName { get; set; }
}
