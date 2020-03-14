using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    public CameraFollowController cameraFollowController;
    private PlayerClass playerClass;
    private static int i = 0;
    private int lap;
    private bool beforeFinishPass = true;
    private float f_horizontalInput;
    private float f_verticalInput;

    public float maxSteerAngle, motorForce, maximumRotation;
    public static bool startGame = false;

    public static PlayerController Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        playerClass = new PlayerClass(gameObject, i, GameManager.Instance.ReturnName(i++), maxSteerAngle, motorForce, maximumRotation);
        playerClass.Text.text = "Speed";
    }
    private void FixedUpdate()
    {
        if(startGame)
            Move();
         playerClass.CountSpeed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (!beforeFinishPass)
            {
                FinishedLap();
                if (GameManager.Instance.numberOfLaps == lap)
                {
                    GameManager.Instance.Win(playerClass.Element);
                    FinishGame();
                }
            }
            Debug.Log(lap);
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
        beforeFinishPass = true;
    }
    public void Move()
    {
        GetInput(playerClass.NameOfInputHorizontal, playerClass.NameOfInputVertical);
        playerClass.Steer(f_horizontalInput);
        playerClass.Rotation(f_horizontalInput);
        if(f_verticalInput<0)
            playerClass.Brake(f_verticalInput);
        else    playerClass.Accelerate(f_verticalInput);
    }
    public void GetInput(string nameOfInputHorizontal, string nameOfInputVertical)
    {
        f_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        f_verticalInput = Input.GetAxis(nameOfInputVertical);
    }
    private void FinishGame()
    {
        cameraFollowController.finishGame = true;
        cameraFollowController.deathOrNot = true;
        gameObject.SetActive(false);
        playerClass.Text.text = "SPECTATE";
        cameraFollowController.ChangeIndex(cameraFollowController.index);
    }
}