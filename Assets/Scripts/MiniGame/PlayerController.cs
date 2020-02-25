using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    private bool tmp = false;
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public float maxSteerAngle;
    public float motorForce;
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    /*
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }


    
        player.frontDriverW = GameObject.Find("WC_FRONTLEFT").GetComponent<WheelCollider>();
        player.frontPassengerW = GameObject.Find("WC_FRONTRIGHT").GetComponent<WheelCollider>();
        player.rearDriverW = GameObject.Find("WC_REARLEFT").GetComponent<WheelCollider>();
        player.rearPassengerW = GameObject.Find("WC_REARRIGHT").GetComponent<WheelCollider>();

        player.frontDriverT = GameObject.Find("WESD_FRONTLEFT").GetComponent<Transform>();
        player.frontPassengerT = GameObject.Find("WESD_FRONTRIGHT").GetComponent<Transform>();
        player.rearDriverT = GameObject.Find("WESD_REARLEFT").GetComponent<Transform>();
        player.rearPassengerT = GameObject.Find("WESD_REARRIGHT").GetComponent<Transform>();


    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical"); //Podesavanje osa za strelice
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput; //Ugao od pritiska strelice
        frontPassengerW.steerAngle = frontDriverW.steerAngle = m_steeringAngle; //Prednji levi tocak 
    }

    public void Accelerate()
    {
        frontPassengerW.motorTorque = frontDriverW.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT); //W collider T tocak
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);//zlzd
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }
    //(_colider=frontDriverW, _transform=frontDriverT)
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position; // Trenutna pozicija
        Quaternion _quat = _transform.rotation; // Tr rot

        _collider.GetWorldPose(out _pos, out _quat); //https://docs.unity3d.com/ScriptReference/WheelCollider.GetWorldPose.html
        _transform.position = _pos; //Dodela
        _transform.rotation = _quat; //Dodela
    }*/
}
