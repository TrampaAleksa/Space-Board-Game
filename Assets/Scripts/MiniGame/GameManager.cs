using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle;
    public float motorForce;

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical"); //Podesavanje osa za strelice
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput; //Ugao od pritiska strelice
        Debug.Log(m_steeringAngle);
        frontPassengerW.steerAngle = frontDriverW.steerAngle = m_steeringAngle; //Prednji levi tocak 
        
    }

    public void Accelerate()
    {
        frontPassengerW.motorTorque = frontDriverW.motorTorque = m_verticalInput *motorForce;
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
    }

    public void PickUp(Color colorPickUp) // desavanja pri kupljenju poena sa prom
    {
    }
    public void CompleteLevel()
    {
        Stop();
    }

     public void completeAll()
     {
         Stop();
     }

    public void CheckPoint()
    {
    }
    public void Die()
    {
        Stop();
    }

    public void Stop()
    {
    }

    public void ButtonClicked()
    {
    }
    
}
