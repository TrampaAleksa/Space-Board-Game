using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollHandler : MonoBehaviour
{
    public Text tDiceNumberRolled;

    private Sprite[] diceSides;

    private Image diceImage;
    public float diceAnimationSpeed = 0.05f;

    private int numberRolled = 0;

    public static int number = 0;
    private int minimumDiceNumber = 1;
    private int maximumDiceNumber = 6;

    private bool diceLocked = false;

    private void Awake()
    {
        diceImage = GameObject.Find("Dice").GetComponent<Image>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    public void DiceWasClicked()
    {
        if (!diceLocked)
        {
            ChangeDiceLockState();
            StartCoroutine(RollTheDice());
        }
        else Debug.Log("Sorry, the dice is locked");
    }

    public bool ChangeDiceLockState()
    {
        return diceLocked = !diceLocked;
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        CameraModesHandler cameraMovementHandler = InstanceManager.Instance.Get<CameraModesHandler>();
        cameraMovementHandler.SetCameraMode(typeof(CameraModePlayerFollow));
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);

            diceImage.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(diceAnimationSpeed);
        }

        numberRolled = randomDiceSide + 1;
        // numberRolled = 2;
        tDiceNumberRolled.text = numberRolled.ToString();
        InstanceManager.Instance.Get<MovementHandler>().MoveCurrentPlayer(numberRolled);
    }

    public bool DiceIsLocked()
    {
        return diceLocked;
    }
}