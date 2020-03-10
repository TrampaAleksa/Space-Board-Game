using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownV3 : MonoBehaviour
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

        this.GetComponent<Timer>().enabled = true;
        this.GetComponent<MovementMechanic>().enabled = true;
        this.GetComponent<SpawnBarrels>().enabled = true;


        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }
}
