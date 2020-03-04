using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private static int i = 0;
    private int lap;
    private bool beforeFinishPass = false;
    private bool playerFinishRace = false;
    private float m_horizontalInput;
    private float m_verticalInput;

    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public float maxSteerAngle;
    public float motorForce;
    public float numberOfLaps;
    public float maximumRotation = 45;

    public PlayerClass playerClass;
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
        playerClass = new PlayerClass(i, GameManager.Instance.ReturnName(i++));
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
        pText.text = "Lap: " + lap.ToString() + "/" + numberOfLaps;
    }
    private void FixedUpdate()
    {
        if (!playerFinishRace)
        {
            GetInput();
            Rotation();
            Steer();
            Accelerate();
        }
        
    }
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        m_verticalInput = Input.GetAxis(nameOfInputVertical); //Podesavanje osa za strelice
    }

    public void Rotation()
    {
        BodyForRotate.transform.localRotation = new Quaternion(0,-(m_horizontalInput* maximumRotation), 0, 180);
    }

    public void Break()
    {
        if(m_verticalInput<0)
            frontRightW.motorTorque = frontLeftW.motorTorque = m_verticalInput * motorForce*10000000;
    }

    public void Steer()
    {
        frontRightW.steerAngle = frontLeftW.steerAngle = maxSteerAngle * m_horizontalInput;
    }

    public void Accelerate()
    {
        frontRightW.motorTorque = frontLeftW.motorTorque = rearLeftW.motorTorque=rearRightW.motorTorque = m_verticalInput * motorForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log(playerClass.Name+" : "+ playerClass.Element);
            if (!beforeFinishPass)
            {
                FinishedLap();
                if (numberOfLaps == lap-1)
                {
                    playerFinishRace = true;
                    GameManager.Instance.Win(playerClass.Element);
                    gameObject.SetActive(false);
                    pPanel.gameObject.SetActive(true);
                    pText.text = playerClass.Name + " je " + GameManager.Instance.playerBoardStates[playerClass.Element].rank + " mesto";
                }
            }
        }

        if (other.tag == "DeathLine")
        {
            beforeFinishPass = true;
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
        pText.text = "Lap: " + (lap - 1).ToString() + "/" + numberOfLaps;
        beforeFinishPass = true;
    }
}
