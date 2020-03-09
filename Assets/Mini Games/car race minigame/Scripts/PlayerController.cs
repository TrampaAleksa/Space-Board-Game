using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private PlayerClass playerClass;
    private static int i = 0;
    private int lap;
    private bool beforeFinishPass = false;
    private float f_horizontalInput;
    private float f_verticalInput;

    public float maxSteerAngle, motorForce, maximumRotation;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public Transform BodyForRotate;
    public static PlayerController Instance;
    public static bool startGame=false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        playerClass = new PlayerClass(gameObject, i, GameManager.Instance.ReturnName(i++), maxSteerAngle, motorForce, maximumRotation);
        playerClass.Panel.gameObject.SetActive(false);
        playerClass.Text.text = "Lap: " + lap.ToString() + "/" + GameManager.Instance.numberOfLaps;
    }
    private void FixedUpdate()
    {
        if(startGame)
            Move();
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
                    FinishGame();
                }
            }
        }
        if (other.tag == "DeathLine")
        {
            GameManager.Instance.Lose(playerClass.Element);
            FinishGame();
        }
        if (other.tag == "NextField")
        {
            beforeFinishPass = false;
        }
    }
    private void FinishedLap()
    {
        lap++;
        playerClass.Text.text = "Lap: " + (lap - 1).ToString() + "/" + GameManager.Instance.numberOfLaps;
        beforeFinishPass = true;
    }
    public void Move()
    {
        GetInput(nameOfInputHorizontal, nameOfInputVertical);
        playerClass.Steer(f_horizontalInput);
        playerClass.Rotation(f_horizontalInput);
        if(f_verticalInput<0)
            playerClass.Break(f_verticalInput);
        else    playerClass.Accelerate(f_verticalInput);
    }
    public void GetInput(string nameOfInputHorizontal, string nameOfInputVertical)
    {
        f_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        f_verticalInput = Input.GetAxis(nameOfInputVertical);
    }
    private void FinishGame()
    {
        gameObject.SetActive(false);
        playerClass.Panel.gameObject.SetActive(true);
        playerClass.Text.text = playerClass.Name + " je " + GameManager.Instance.playerBoardStates[playerClass.Element].rank + " mesto";
    }
}