using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private int lap;
    private bool beforeFinishPass = false;
    private bool playerFinishRace = false;
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private int num;

    private Text[] pText;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public WheelCollider frontLeftW, frontRightW,
                         rearLeftW, rearRightW;
    public Transform frontLeftT, frontRightT,
                     rearLeftT, rearRightT;
    public float maxSteerAngle;
    public float motorForce;
    public float numberOfLaps;

    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        WheelCollider[] wheelColliders = gameObject.GetComponentsInChildren<WheelCollider>();
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 4; i++)
        {
            if (wheelColliders[i].name == "WC_FRONTLEFT")
                frontLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_FRONTRIGHT")
                frontRightW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARLEFT")
                rearLeftW = wheelColliders[i];
            else if (wheelColliders[i].name == "WC_REARRIGHT")
                rearRightW = wheelColliders[i];

            if (transforms[i + 1].name == "WESD_FRONTLEFT")
                frontLeftT = transforms[i + 1];
            if (transforms[i + 1].name == "WESD_FRONTRIGHT")
                frontRightT = transforms[i + 1];
            if (transforms[i + 1].name == "WESD_REARLEFT")
                rearLeftT = transforms[i + 1];
            if (transforms[i + 1].name == "WESD_REARRIGHT")
                rearRightT = transforms[i + 1];
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
            Steer();
            Accelerate();
        }
        UpdateWheelPoses();
        
    }
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        m_verticalInput = Input.GetAxis(nameOfInputVertical); //Podesavanje osa za strelice
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput; //Ugao od pritiska strelice
        frontRightW.steerAngle = frontLeftW.steerAngle = m_steeringAngle; //Prednji levi tocak 
    }

    public void Accelerate()
    {
        frontRightW.motorTorque = frontLeftW.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftW, frontLeftT);
        UpdateWheelPose(frontRightW, frontRightT);
        UpdateWheelPose(rearLeftW, rearLeftT);
        UpdateWheelPose(rearRightW, rearRightT);
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position; // Trenutna pozicija
        Quaternion _quat = _transform.rotation; // Tr rot

        _collider.GetWorldPose(out _pos, out _quat); //https://docs.unity3d.com/ScriptReference/WheelCollider.GetWorldPose.html
        _transform.position = _pos; //Dodela
        _transform.rotation = _quat; //Dodela
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
                GameManager.Instance.PlayerFinishRace(gameObject.name);
                FinishedLap();
            }
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
