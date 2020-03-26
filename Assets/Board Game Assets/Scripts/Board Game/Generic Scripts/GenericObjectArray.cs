using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectArray : MonoBehaviour
{
    
    public GameObject[] gameObjects;
    private int currentMemberIndex = 0;
    protected int CurrentMemberIndex { get => currentMemberIndex; set => currentMemberIndex = value; }

    public GameObject FirstMember()
    {
        return gameObjects[0];
    }

    public GameObject LastMember()
    {
        return gameObjects[gameObjects.Length - 1];
    }

    /// <summary>
    /// Returns the next member in the array without changing the CurrentMemberIndex
    /// </summary>
    /// <returns>The next member in the array</returns>
    public GameObject NextMember()
    {
        int nextMember = (CurrentMemberIndex + 1) % gameObjects.Length;
        return gameObjects[nextMember];
    }

    /// <summary>
    /// Returns the previous member in the array without changing the CurrentMemberIndex
    /// </summary>
    /// <returns>The previous member in the array</returns>
    public GameObject PreviousMember()
    {
        int previousMember = CurrentMemberIndex == 0 ?
            gameObjects.Length - 1 :
            CurrentMemberIndex - 1;

        return gameObjects[previousMember];
    }

    public GameObject SetToNextMember()
    {
        int nextMember = (CurrentMemberIndex + 1) % gameObjects.Length;
        CurrentMemberIndex = nextMember;
        return CurrentMember();
    }

    public GameObject MemberWithIndex(int index)
    {
        while (index >= gameObjects.Length)
        {
            index -= gameObjects.Length;
        }
        while (index < 0) index += gameObjects.Length;
        return gameObjects[index];
    }

    public GameObject CurrentMember()
    {
        return gameObjects[CurrentMemberIndex];
    }

    /// <summary>
    /// Returns the given member in the array and sets the Current Member Index to that member.
    /// The index can be out of bounds as it loops to the first
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject SetCurrentMember(int index)
    {
        while (index >= gameObjects.Length)
        {
            index -= gameObjects.Length;
        }
        while (index < 0) index += gameObjects.Length;
        CurrentMemberIndex = index;
        return gameObjects[CurrentMemberIndex];
    }

    public int LastMemberIndex()
    {
        return gameObjects.Length - 1;
    }

    public int ArrayLength()
    {
        return gameObjects.Length;
    }
    public void ExcludeElement(int index)
    {
        int lenght = gameObjects.Length - 1;
        GameObject[] tmpGameObjects = new GameObject[lenght];
        for (int a = index; a < gameObjects.Length-1; a++)
        {
            gameObjects[a] = gameObjects[a + 1];
        }
        for (int a = 0; a < tmpGameObjects.Length; a++)
        {
            tmpGameObjects[a] = gameObjects[a];
        }
        gameObjects = tmpGameObjects;
    }
}