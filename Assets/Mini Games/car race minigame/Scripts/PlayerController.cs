using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PathCreation;

public partial class PlayerController : MonoBehaviour
{
    public CameraFollowController cameraFollowController;
    private PlayerClass playerClass;
    private static PlayerClass[] players= new PlayerClass[4];
    private static int i = 0;
    private static int count = 0;
    private int lap;
    private bool beforeFinishPass = true;
    private float f_horizontalInput;
    private float f_verticalInput;
    public PathCreator pathCreator;

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
        if(startGame){
            Move();
        }
         playerClass.CountSpeed();
         
    }
    private void OnTriggerEnter(Collider other)
    {
        print(pathCreator.path.GetClosestDistanceAlongPath(transform.localPosition));
        if (other.tag == "Finish")
        {
            if (!beforeFinishPass)
            {
                FinishedLap();
                if (GameManager.Instance.numberOfLaps == lap)
                {
                    FinishGame();
                }
            }
        }
        if (other.tag == "DeathLine")
        {
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
        count++;
        if(!beforeFinishPass)
        playerClass.Distance=pathCreator.path.GetClosestDistanceAlongPath(transform.localPosition);
        cameraFollowController.finishGame = true;
        cameraFollowController.deathOrNot = true;
        gameObject.SetActive(false);
        playerClass.Text.text = "SPECTATE";
        cameraFollowController.ChangeIndex(cameraFollowController.index);
        if(count==4){
            players[count]=playerClass;
            GameManager.Instance.PlayerDeath(players);
        }
    }
}