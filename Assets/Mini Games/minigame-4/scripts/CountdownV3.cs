using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownV3 : MonoBehaviour
{
    public int countdwonTime;
    public Text countdownDisplay;
    public Timer timer;
    public MovementMechanic movementMechanic;
    public SpawnBarrels spawnBarrels;


    private void Start()
    {
        timer.enabled=false;
        movementMechanic.enabled=false;
        spawnBarrels.enabled=false;
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

        timer.enabled = true;
        movementMechanic.enabled = true;
        spawnBarrels.enabled = true;


        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }
}
