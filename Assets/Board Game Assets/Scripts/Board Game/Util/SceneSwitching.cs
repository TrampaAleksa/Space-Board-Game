using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BoardStateHandler.Instance.SaveBoardState();
            var miniGameHandler = InstanceManager.Instance.Get<MiniGameHandler>();
            miniGameHandler.SwitchToRandomMiniGame(miniGameHandler.miniGameSceneNames);
        }
    }
}