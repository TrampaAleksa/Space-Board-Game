using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownControllerMG5 : MonoBehaviour
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

        this.GetComponent<BallsRoll>().enabled = true;
        this.GetComponent<TimerMG5>().enabled = true;

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

}
