using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.LowLevel.PlayerLoop;

public class VictoryHandler : MonoBehaviour
{
    public  WinScreenPanelHandler winScreenPanel;
    public GameObject winScreenPanelObj;

    public static VictoryHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Win(GameObject[] players)
    {
        // InstanceManager.Instance.Get<TooltipHandler>().ShowPlayersTooltip(player, "WON THE GAME");
        //winScreenPanelObj.SetActive(true);
        winScreenPanel.InjectScoreValues(TopPlayers(3, players))
                    .ShowWinScreen();
    }
    
    public  bool CheckGameWon(float playerFuel)
    {
        return playerFuel >= FuelHandler.WinningAmount;
    }

    private List<GameObject> TopPlayers(int numberOfPlayers, GameObject[] players)
    {
        List<GameObject> topPlayers = new List<GameObject>();
        
        var sortedPlayers = 
            (from playerFuel in players
            orderby playerFuel.GetComponent<PlayerFuel>().fuel descending 
            select playerFuel)
            .ToArray();
        
        for (int i = 0; i < numberOfPlayers; i++)
        {
            topPlayers.Add(sortedPlayers[i]);
        }

        return topPlayers;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
        }
    }
}
