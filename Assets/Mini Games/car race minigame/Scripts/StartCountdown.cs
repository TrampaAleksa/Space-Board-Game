using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    public GameObject cameraMap;
    public int countdwonTime;
    public Text countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    private IEnumerator CountdownToStart()
    {
        cameraMap.SetActive(false);
        for(int i=0;i<GameManager.Instance.panels.Count;i++)
            GameManager.Instance.TypeName(i);
        while (countdwonTime > 0)
        {
            countdownDisplay.text = countdwonTime.ToString();

            yield return new WaitForSeconds(1f);

            countdwonTime--;
        }
        
        countdownDisplay.text = "GO!";
        
        PlayerController.startGame = true;

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
        cameraMap.SetActive(true);
        for(int i=0;i<GameManager.Instance.panels.Count;i++){
                GameManager.Instance.panels[i].playerNameText.gameObject.SetActive(false);
                GameManager.Instance.SetPosition(i);
        }
    }
}