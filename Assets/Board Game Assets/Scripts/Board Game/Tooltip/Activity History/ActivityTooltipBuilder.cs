using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivityTooltipBuilder
{
    public string tooltipMessage;
    private readonly ActivityHistoryHandler _activityHistoryHandler;
    protected string player1Name { get; }
    protected string player2Name { get; }
    protected string value { get; }

    protected ActivityTooltipBuilder()
    {
        _activityHistoryHandler = InstanceManager.Instance.Get<ActivityHistoryHandler>();
    }
    
    protected ActivityTooltipBuilder(GameObject player1): this()
    {
        string player1Name = player1.GetComponent<PlayerName>().playerName.text;
        string color = player1.GetComponent<Player>().color;
        player1Name = RichTextBuilder.AddTagToString(player1Name, "color", color);
        
        this.player1Name = player1Name;
    }

    protected ActivityTooltipBuilder(GameObject player1, GameObject player2): this()
    {
        string player1Name = player1.GetComponent<PlayerName>().playerName.text;
        string player2Name = player2.GetComponent<PlayerName>().playerName.text;
        string color1 = player1.GetComponent<Player>().color;
        string color2 = player2.GetComponent<Player>().color;

        player1Name = RichTextBuilder.AddTagToString(player1Name, "color", color1);
        player2Name = RichTextBuilder.AddTagToString(player2Name, "color", color2);
        
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    protected ActivityTooltipBuilder(GameObject player1, int value): this()
    {
        string player1Name = player1.GetComponent<PlayerName>().playerName.text;
        string color = player1.GetComponent<Player>().color;

        player1Name = RichTextBuilder.AddTagToString(player1Name, "color", color);
        string valueColored = RichTextBuilder.AddTagToString(value.ToString(), "color", color);
        
        this.player1Name = player1Name;
        this.value = valueColored;
    }

    protected ActivityTooltipBuilder(GameObject player1, GameObject player2, int value): this()
    {
        string player1Name = player1.GetComponent<PlayerName>().playerName.text;
        string player2Name = player2.GetComponent<PlayerName>().playerName.text;
        string color1 = player1.GetComponent<Player>().color;
        string color2 = player2.GetComponent<Player>().color;

        player1Name = RichTextBuilder.AddTagToString(player1Name, "color", color1);
        player2Name = RichTextBuilder.AddTagToString(player2Name, "color", color2);
        string valueColored = RichTextBuilder.AddTagToString(value.ToString(), "color", color1);
        
        this.player1Name = player1Name;
        this.player2Name = player2Name;
        this.value = valueColored;
    }

    public void DisplayAT()
    {
        _activityHistoryHandler.ShowActivityTooltipMessage(tooltipMessage);
    }

    public abstract void BuildActivityTooltip();
}