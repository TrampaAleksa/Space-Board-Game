using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice
{
    private int minimumDiceNumber;
    private int maximumDiceNumber;

    private float diceAnimationSpeed;

    private Sprite[] diceSides;
    private Image diceImage;

    public Dice(int minimumDiceNumber, int maximumDiceNumber, float diceAnimationSpeed, Sprite[] diceSides, Image diceImage)
    {
        MinimumDiceNumber = minimumDiceNumber;
        MaximumDiceNumber = maximumDiceNumber;
        DiceAnimationSpeed = diceAnimationSpeed;
        DiceSides = diceSides;
        DiceImage = diceImage;
    }

    public int MinimumDiceNumber { get => minimumDiceNumber; set => minimumDiceNumber = value; }
    public int MaximumDiceNumber { get => maximumDiceNumber; set => maximumDiceNumber = value; }
    public float DiceAnimationSpeed { get => diceAnimationSpeed; set => diceAnimationSpeed = value; }
    public Sprite[] DiceSides { get => diceSides; set => diceSides = value; }
    public Image DiceImage { get => diceImage; set => diceImage = value; }
}