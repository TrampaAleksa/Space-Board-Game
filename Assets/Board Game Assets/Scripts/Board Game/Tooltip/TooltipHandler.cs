using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour
{
    private TextTooltip fieldInfoTooltip;
    private TextTooltip infoTooltip;

    private void Awake()
    {
        InitializeTooltips();
    }

    public void InitializeTooltips()
    {
        fieldInfoTooltip = GameObject.Find("FieldInfoTooltip").GetComponentInChildren<TextTooltip>();
        infoTooltip = GameObject.Find("InfoTooltip").GetComponentInChildren<TextTooltip>();

        GameObject[] players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        TextMeshTooltip[] tooltipHolders = GameObject.Find("PlayerContainer").GetComponentsInChildren<TextMeshTooltip>();
        if (tooltipHolders.Length != players.Length) print("number of tooltip holders not equal to players");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerTooltip>().tooltip = tooltipHolders[i];
        }
    }

    public void ShowPlayersTooltip(GameObject player, string message)
    {
        player.GetComponent<PlayerTooltip>().tooltip.ShowTooltip(message);
    }

    public void ShowInfoTooltip(string message)
    {
        infoTooltip.ShowTooltip(message);
    }

    public void ShowFieldInfoTooltip(string message)
    {
        fieldInfoTooltip.ShowTooltip(message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowPlayersTooltip(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), "-30 Fuel");
        }
    }
}