using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdwonTime;
    public Text countdownDisplay;
    

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdwonTime > 0)
        {
            countdownDisplay.text = countdwonTime.ToString();

            yield return new WaitForSeconds(1f);

            countdwonTime--;
        }

        countdownDisplay.text = "GO!";

        this.GetComponent<PlayerMovementV2>().enabled = true;
        this.GetComponent<EnemyAIV2>().enabled=true;
        


        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }
  
}
