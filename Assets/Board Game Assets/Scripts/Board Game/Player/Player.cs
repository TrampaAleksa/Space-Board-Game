using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected FieldHandler path;

    [SerializeField]
    public Field currentPlayerField;

    public int turnsToSkip;
    public string color;

    private void Awake()
    {
        //TODO -- refactor and extract methods for getting specific player
        switch (gameObject.name)
        {
            case "Player 1":
                color = "grey";
                break;

            case "Player 2":
                color = "green";
                break;

            case "Player 3":
                color = "yellow";
                break;

            case "Player 4":
                color = "red";
                break;
        }
    }

    public bool EnginesBroken()
    {
        return turnsToSkip > 0;
    }
}