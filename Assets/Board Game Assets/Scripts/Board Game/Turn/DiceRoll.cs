using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll
{
    public Dice dice;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private float diceAnimationSpeed = 0.01f;

    public DiceRoll()
    {
        dice = new Dice(
                minimumDiceNumber,
                maximumDiceNumber,
                diceAnimationSpeed,
                Resources.LoadAll<Sprite>("DiceSides/"),
                GameObject.Find("Dice").GetComponent<Image>()
       );
    }

    public IEnumerator RollTheDiceAnim()
    {
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(dice.MinimumDiceNumber, dice.MaximumDiceNumber);

            dice.DiceImage.sprite = dice.DiceSides[randomDiceSide];

            yield return new WaitForSeconds(dice.DiceAnimationSpeed);
        }
        int numberRolled = randomDiceSide + 1;
        InstanceManager.Instance.Get<DiceRollHandler>().numberRolled = numberRolled;
        numberRolled = 3; // use to fix what the dice will roll, for testing
        InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(numberRolled);
    }
}