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
            TriggerMiniGame();
        }
    }

    private void TriggerMiniGame()
    {
        InstanceManager.Instance.Get<DiceRollHandler>().LockTheDice();
        InstanceManager.Instance.Get<TooltipHandler>().ShowInfoTooltip("Mini game triggered!");
        StartCoroutine(SwitchToRandomMiniGame(miniGameSceneNames));
        turnsElapsed = 0;
    }
    
    public IEnumerator SwitchToRandomMiniGame(string[] sceneNamesArray)
    {
        yield return new WaitForSeconds(3f);
        if (sceneNamesArray.Length > 0)
        {
            var randomIndex = Random.Range(0, sceneNamesArray.Length);
            BoardStateHandler.Instance.SaveBoardState();
            SceneManager.LoadScene(sceneNamesArray[randomIndex]);
        }
    }
}
