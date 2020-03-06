using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private PlayerClass playerClass;
    private static int i = 0;
    private int lap;
    private bool beforeFinishPass = false;

    public float maxSteerAngle, motorForce, 
                    maximumRotation;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;

    public Text pText;
    public Transform pPanel;
    public Transform BodyForRotate;
    public WheelCollider frontLeftW, frontRightW,
                         rearLeftW, rearRightW;

    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        playerClass = new PlayerClass(i, GameManager.Instance.ReturnName(i++), maxSteerAngle, motorForce, maximumRotation);
        WheelCollider[] wheelColliders = gameObject.GetComponentsInChildren<WheelCollider>();
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            if (wheelColliders[i].name == "WC_FRONTLEFT")
                frontLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_FRONTRIGHT")
                frontRightW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARLEFT")
                rearLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARRIGHT")
                rearRightW = wheelColliders[i];
        }
        pPanel.gameObject.SetActive(false);
        pText.text = "Lap: " + lap.ToString() + "/" + GameManager.Instance.numberOfLaps;
    }
    private void FixedUpdate()
    {
        CarMovement.Instance.Move(frontRightW, frontLeftW, rearLeftW, rearRightW, playerClass.MotorForce, playerClass.MaxSteerAngle, playerClass.MaximumRotation, BodyForRotate, nameOfInputHorizontal, nameOfInputVertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (!beforeFinishPass)
            {
                FinishedLap();
                if (GameManager.Instance.numberOfLaps == lap-1)
                {
                    GameManager.Instance.Win(playerClass.Element);
                    gameObject.SetActive(false);
                    pPanel.gameObject.SetActive(true);
                    pText.text = playerClass.Name + " je " + GameManager.Instance.playerBoardStates[playerClass.Element].rank + " mesto";
                }
            }
        }

        if (other.tag == "DeathLine")
        {
            GameManager.Instance.Lose(playerClass.Element);
            gameObject.SetActive(false);
            pPanel.gameObject.SetActive(true);
            pText.text = playerClass.Name + " je " + GameManager.Instance.playerBoardStates[playerClass.Element].rank + " mesto";
        }


        if (other.tag == "NextField")
        {
            beforeFinishPass = false;
        }
    }
    private void FinishedLap()
    {
        lap++;
        pText.text = "Lap: " + (lap - 1).ToString() + "/" + GameManager.Instance.numberOfLaps;
        beforeFinishPass = true;
    }
}
