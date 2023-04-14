using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenPanelHandler : MonoBehaviour
{
    public Text[] names;
    public Text[] values;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public WinScreenPanelHandler ShowWinScreen()
    {
        gameObject.SetActive(true);
        gameOver = true;
        return this;
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
       
    }


    public WinScreenPanelHandler InjectScoreValues(List<GameObject> players)
    {
        for (var i = 0; i < players.Count; i++)
        {
            var player = players[i];
            names[i].text = player.GetComponent<PlayerName>().playerName.text;
            values[i].text = "- " + Convert.ToInt32(player.GetComponent<PlayerFuel>().fuel).ToString() + " -";
        };
        return this;
    }
    
}

