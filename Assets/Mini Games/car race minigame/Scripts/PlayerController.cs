using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PathCreation;

public partial class PlayerController : MonoBehaviour
{
    private int position=0;
    public GameObject allWheelColliders;
    private Rigidbody rigidBody;
    private MeshCollider meshCollider;
    public CameraFollowController cameraFollowController;
    private PlayerClass playerClass;
    private static int i = 0;
    public GameObject speedText;
    public GameObject playerNameText;
    public GameObject localRankPositionText;
    private float f_horizontalInput;
    private float f_verticalInput;
    private bool playerTriggerCollision=false;
    private bool playerRespawn=false;
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
        rigidBody=gameObject.GetComponent<Rigidbody>();
        meshCollider=gameObject.GetComponent<MeshCollider>();
        playerClass = new PlayerClass(gameObject, i, GameManager.Instance.ReturnName(i), maxSteerAngle, motorForce, maximumRotation);
        i++;
    }
    public int ReturnIndex()
    {
        return playerClass.Element;
    }
    private void FixedUpdate()
    {
        if(startGame && !playerRespawn)
        {
            Move();
        }
        speedText.GetComponent<Text>().text =playerClass.CountSpeed();
    }
    void OnTriggerExit(Collider other)
    {
        playerTriggerCollision=false;
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
            if(!other.GetComponent<MeshCollider>().isTrigger)
                playerTriggerCollision=true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathLine"){
            Respawn();
        }
        else if (other.tag == "Finish")
        {
            GameManager.Instance.PlayerDeath(playerClass.Element, cameraFollowController);
            gameObject.SetActive(false);
            speedText.GetComponent<Text>().text = "SPECTATE";
        }
    }    
    void Update()
    {
        if(Input.GetAxis(playerClass.NameOfRespawnButton)==1 && startGame)
            Respawn();
        if((Input.GetAxis(playerClass.NameOfInputHorizontal)>0 || Input.GetAxis(playerClass.NameOfInputVertical)!=0) && !playerTriggerCollision)
            RespawnState(false);
    }
    public void Move()
    {
        GetInput(playerClass.NameOfInputHorizontal, playerClass.NameOfInputVertical);
        playerClass.Steer(f_horizontalInput);
        playerClass.RotateBody(f_horizontalInput);
        if(f_verticalInput<0)
            playerClass.Brake(f_verticalInput);
        else    playerClass.Accelerate(f_verticalInput);
    }
    public void GetInput(string nameOfInputHorizontal, string nameOfInputVertical)
    {
        f_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        f_verticalInput = Input.GetAxis(nameOfInputVertical);
    }
    public void Respawn()
    {
        float distance=pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        gameObject.transform.localRotation=pathCreator.path.GetRotationAtDistance(distance);
        gameObject.transform.localEulerAngles= new Vector3 (transform.localEulerAngles.x,transform.localEulerAngles.y, 0);
        gameObject.transform.position=pathCreator.path.GetClosestPointOnPath(transform.position)+new Vector3(0,0.8f,0);
        RespawnState(true);
    }
    private void RespawnState(bool state)
    {
        rigidBody.isKinematic=state;
        meshCollider.isTrigger=state;
        allWheelColliders.SetActive(!state);
        playerRespawn=state;
    }
    public void UpdateLocalRank(int pos,int checkpoint)
    {
        position=pos;
        localRankPositionText.GetComponent<Text>().text="checkpoint"+checkpoint+" "+"0"+position+"/04";
    }
}