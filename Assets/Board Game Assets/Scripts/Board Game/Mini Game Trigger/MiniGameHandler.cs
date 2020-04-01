using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHandler : MonoBehaviour
{
    public int turnsBeforeTriggering = 8;
    public string[] miniGameSceneNames;
    public int turnsElapsed = 0;
    
    public void TryTriggerMiniGame()
    {
        if (turnsElapsed < turnsBeforeTriggering)
        {
            turnsElapsed++;
        }
        else
        {
            SwitchToRandomMiniGame(miniGameSceneNames);
            turnsElapsed = 0;
        }
    }
    
    public void SwitchToRandomMiniGame(string[] sceneNamesArray)
    {
        if (sceneNamesArray.Length > 0)
        {
            var randomIndex = Random.Range(0, sceneNamesArray.Length);
            BoardStateHandler.Instance.SaveBoardState();
            SceneManager.LoadScene(sceneNamesArray[randomIndex]);
        }
    }
}
