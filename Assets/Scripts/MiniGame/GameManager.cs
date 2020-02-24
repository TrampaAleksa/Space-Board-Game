using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pan; //panel
    public Text winText;//na kraju levela tekst
    public Button btn;//dugme na kraju levela

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle;
    public float motorForce;

    int pom=4;
    bool finishBtn;
    bool fullFinish;

    void Start()
    {
        pan.SetActive(false);
        fullFinish = false;
        Time.timeScale = 0;//Zamrzavamo vreme
    }

    void Update()
    {
        if (fullFinish == false)
            if (Input.anyKeyDown)//pitam da li je dugme neko dole
            {
                Time.timeScale = 1;//Odmrzavam vreme
            }
    }

    private void FixedUpdate()
    {
            GetInput();
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical"); //Podesavanje osa za strelice
        Steer();
    }

    private void Steer()
    {

        m_steeringAngle = maxSteerAngle * m_horizontalInput; //Ugao od pritiska strelice
        frontPassengerW.steerAngle = frontDriverW.steerAngle = m_steeringAngle; //Prednji levi tocak 
        if(pom==4) //sve je normalno
            Accelerate(motorForce);
        else if (pom == 3)// da bi postojao delay
        {
            if (frontDriverW.motorTorque > motorForce) 
                Accelerate(frontDriverW.motorTorque - 1);//vrati ga na motorForce brzinu
            else if (frontDriverW.motorTorque < motorForce)
                Accelerate(frontDriverW.motorTorque + 1);//vrati ga na motorForce brzinu
            else if (frontDriverW.motorTorque == motorForce)
            {
                pom = 4;
                Accelerate(motorForce);
            }
        }
        if (pom == 1) //pokupili smo plavu
        {
            pom = 3;
            Accelerate(10);
        }
        else if (pom == 2) //pokupili smo zelenu
        {
            pom = 3;
            Accelerate(frontDriverW.motorTorque * 2);
        }
    }

    public void Accelerate(float ubrzaj)
    {
        frontPassengerW.motorTorque = frontDriverW.motorTorque = m_verticalInput *ubrzaj;
        UpdateWheelPoses();
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
        if (colorPickUp == Color.blue)
        {
            pom = 1;
        }
        else if (colorPickUp == Color.black)
            Die();
        else { pom = 2;}
    }
    public void CompleteLevel()
    {
        finishBtn = true;
        winText.text = "Finish!" + "\n";
        btn.transform.GetChild(0).GetComponent<Text>().text = "Next level";//Promena teksta dugmeta
        Stop();
    }

     public void completeAll()
     {
         finishBtn = true;
         btn.transform.GetChild(0).GetComponent<Text>().text = "Finish";
         winText.text = "You have finished all levels!";
         Stop();
     }

    public void CheckPoint()
    {
        pom = 1;
    }
    public void Die()
    {
        finishBtn = false;
        btn.transform.GetChild(0).GetComponent<Text>().text = "Main menu";
        winText.text = "Better luck next time";
        Stop();
    }

    public void Stop()
    {
        pan.SetActive(true);//Aktiviran panel
        fullFinish = true;//Boolean postavljam da je gotov level
        btn.onClick.AddListener(() => ButtonClicked()); //Slusa da li je kliknuto na dugme
        Time.timeScale = 0; //Gasi vreme
    }

    public void ButtonClicked()
    {
        if (finishBtn == false)
            SceneManager.LoadScene("Mainmenu");
        if (finishBtn == true) {
            if (SceneManager.GetActiveScene().buildIndex == 3)//Zavrsili smo poslednji nivo(index treceg)
                SceneManager.LoadScene("Mainmenu");
            else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//naredni level
            }
    }
    
}
