using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private int lap;
    public bool beforeFinishPass = false;
    private bool playerFinishRace = false;
    private float m_horizontalInput;
    private float m_verticalInput;
    private int num;
    private Text[] pText;
    public Transform panel;

    public float maximumRotation=45;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public float maxSteerAngle;
    public float motorForce;
    public float numberOfLaps;

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
        pText = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        num = int.Parse(gameObject.name);
        pText[num - 1].text = "Lap: " + lap.ToString() + "/" + numberOfLaps;
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
            if (numberOfLaps!=lap) 
            {
                if (!beforeFinishPass)
                {
                    FinishedLap();
                } 
            }
            else
            {
                playerFinishRace = true;
                GameManager.Instance.Win(num);
                FinishedLap();
                gameObject.SetActive(false);
            }
        }

        if (other.tag == "DeathLine")
        {
            beforeFinishPass = true;
            gameObject.SetActive(false);
            GameManager.Instance.Lose(num);
            panel.gameObject.SetActive(true);
            pText[num - 1].text = "Your position: "+ (GameManager.Instance.counterRankDec+1);
        }


        if (other.tag == "NextField")
        {
            beforeFinishPass = false;
        }
    }
    private void FinishedLap()
    {
        lap++;
        pText[num - 1].text = "Lap: " + (lap - 1).ToString() + "/" + numberOfLaps;
        beforeFinishPass = true;
    }
}
