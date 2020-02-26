using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private bool beforeFinishPass = false;
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private int num;


    public Text[] pText;
    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public WheelCollider frontLeftW, frontRightW,
                         rearLeftW, rearRightW;
    public Transform frontLeftT, frontRightT,
                     rearLeftT, rearRightT;
    public float maxSteerAngle;
    public float motorForce;

    public int lap;

    public static PlayerController Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        pText = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        num = int.Parse(gameObject.name);
        Debug.Log(num);
    }
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
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
            if (!beforeFinishPass)
            {
                lap++;
                pText[num-1].text = "Lap: "+lap.ToString();
                beforeFinishPass = true;
            }
        }

        if (other.tag == "NextField")
        {
            beforeFinishPass = false;
        }
    }
}
