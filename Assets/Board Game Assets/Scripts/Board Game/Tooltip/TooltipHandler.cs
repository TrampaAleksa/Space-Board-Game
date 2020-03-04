using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour
{
    public const float TOOLTIP_TIME_SHORT = 2f;
    public const float TOOLTIP_TIME_NORMAL = 5f;
    public const float TOOLTIP_TIME_LONG = 10f;
    public TextTooltip fieldInfoTooltip;
    public TextTooltip playerInfoTooltip;

    private void Awake()
    {
        fieldInfoTooltip = GameObject.Find("FieldInfoTooltip").GetComponentInChildren<TextTooltip>();
        playerInfoTooltip = GameObject.Find("InfoTooltip").GetComponentInChildren<TextTooltip>();
        GameObject[] tooltipObjs = GameObject.FindGameObjectsWithTag("Tooltip");
        foreach (var tooltip in tooltipObjs)
        {
            if (tooltip.GetComponent<ITooltipAction>() == null)
                tooltip.AddComponent<TextTooltip>();
        }
    }

    public void ShowTooltip(TextTooltip tooltipToShow, string message)
    {
        tooltipToShow.ShowTooltip(message);
    }

    /// <summary>
    /// If you sometimes need to get the reference to a specific tooltip, use this method
    /// </summary>
    /// <param name="name">The name of the gameobject the tooltip is attached to</param>
    /// <returns>The tooltip component from the game object found</returns>
    public TextTooltip FindTooltipByGameObjectName(string name)
    {
        TextTooltip tooltipFound = GameObject.Find(name).GetComponent<TextTooltip>();
        if (tooltipFound == null)
        {
            Debug.Log("Error, tooltip was not found, wrong name or no component attached");
        }
        return tooltipFound;
    }

    public void ShowPlayersTooltip(GameObject player, string message)
    {
        player.GetComponent<PlayerTooltip>().tooltip.ShowTooltip(message);
    }

    public void ShowInfoTooltip(string message)
    {
        ShowTooltip(playerInfoTooltip, message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowPlayersTooltip(InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer(), "-30 Fuel");
        }
    }
}