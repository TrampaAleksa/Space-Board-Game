using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public string nameOfInputHorizontal;
    public string nameOfInputVertical;
    public WheelCollider frontLeftW, frontRightW,
                         rearLeftW, rearRightW;
    public Transform frontLeftT, frontRightT,
                     rearLeftT, rearRightT;
    public float maxSteerAngle;
    public float motorForce;
    public static PlayerController Instance;
    private void Awake()
    {
        Instance = this;
    }
    
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

        /*
        player.frontDriverW = GameObject.Find("WC_FRONTLEFT").GetComponent<WheelCollider>();
        player.frontPassengerW = GameObject.Find("WC_FRONTRIGHT").GetComponent<WheelCollider>();
        player.rearDriverW = GameObject.Find("WC_REARLEFT").GetComponent<WheelCollider>();
        player.rearPassengerW = GameObject.Find("WC_REARRIGHT").GetComponent<WheelCollider>();

        player.frontDriverT = GameObject.Find("WESD_FRONTLEFT").GetComponent<Transform>();
        player.frontPassengerT = GameObject.Find("WESD_FRONTRIGHT").GetComponent<Transform>();
        player.rearDriverT = GameObject.Find("WESD_REARLEFT").GetComponent<Transform>();
        player.rearPassengerT = GameObject.Find("WESD_REARRIGHT").GetComponent<Transform>();
        */

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
    //(_colider=frontDriverW, _transform=frontDriverT)
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position; // Trenutna pozicija
        Quaternion _quat = _transform.rotation; // Tr rot

        _collider.GetWorldPose(out _pos, out _quat); //https://docs.unity3d.com/ScriptReference/WheelCollider.GetWorldPose.html
        _transform.position = _pos; //Dodela
        _transform.rotation = _quat; //Dodela
    }
}
