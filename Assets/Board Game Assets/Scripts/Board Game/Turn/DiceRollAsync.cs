using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceRollAsync 
{
    public Dice dice;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private float diceAnimationSpeed = 20f;

    public DiceRollAsync()
    {
        dice = new Dice(
            minimumDiceNumber,
            maximumDiceNumber,
            diceAnimationSpeed,
            Resources.LoadAll<Sprite>("DiceSides/"),
            GameObject.Find("Dice").GetComponent<Image>()
        );
    }

    public async Task<int> RollDiceTheDiceAnim()
    {
        try
        {
            int randomDiceSide = 0;
            AudioManager.Instance.PlaySound("diceRoll");
            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = Random.Range(dice.MinimumDiceNumber-1, dice.MaximumDiceNumber);

                dice.DiceImage.sprite = dice.DiceSides[randomDiceSide];

                await Task.Delay((int)dice.DiceAnimationSpeed);
            }
            int numberRolled = randomDiceSide + 1;
            return numberRolled;
        }
        catch
        {
            Debug.Log("error");
        }

        return 0;
    }

}
