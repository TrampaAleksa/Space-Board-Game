using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMiniGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0) SceneManager.LoadScene(0);
            else
            {
                InstanceManager.Instance.Get<MiniGameHandler>().SnapshotBoardState();
                SceneManager.LoadScene(1);
            }
        }
    }
}
