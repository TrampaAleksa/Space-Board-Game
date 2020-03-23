using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    protected FieldHandler path;

    [SerializeField]
    public Field currentPlayerField;

    public int turnsToSkip;
    public string color;

    private void Awake()
    {
        //TODO -- refactor and extract methods for getting specific player
        InitializePlayerColors();
    }

    private void InitializePlayerColors()
    {
        switch (gameObject.name)
        {
            case "Player 1":
                color = PlayerColor.Player1Color;
                break;

            case "Player 2":
                color = PlayerColor.Player2Color;
                break;

            case "Player 3":
                color = PlayerColor.Player3Color;
                break;

            case "Player 4":
                color = PlayerColor.Player4Color;
                break;
        }
    }

    public bool EnginesBroken()
    {
        return turnsToSkip > 0;
    }
}