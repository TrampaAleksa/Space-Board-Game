using UnityEngine;

public interface IPlayerFieldMovement
{
    bool MoveNFields(int n, GameObject player);

    GameObject MoveToNextField(GameObject player);
   
    GameObject MoveToPreviousField(GameObject player);
   
}