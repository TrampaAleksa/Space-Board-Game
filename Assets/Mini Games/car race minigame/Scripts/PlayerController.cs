using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PathCreation;

public partial class PlayerController : MonoBehaviour
{
    public GameObject allWheelColliders;
    private Rigidbody rigidBody;
    private MeshCollider meshCollider;
    public CameraFollowController cameraFollowController;
    private PlayerClass playerClass;
    private static int i = 0;
    private float f_horizontalInput;
    private float f_verticalInput;
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
        print(playerClass.Element+" "+playerClass.NameOfPlayer+" "+playerClass.PlayerObject.name);
        i++;
        playerClass.Text.text = "Speed";
    }
    private void FixedUpdate()
    {
        if(startGame && !playerRespawn)
            Move();
        playerClass.CountSpeed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
            {
                GameManager.Instance.PlayerDeath(playerClass.Element, cameraFollowController);
                gameObject.SetActive(false);
                playerClass.Text.text = "SPECTATE";
            }
        if (other.tag == "DeathLine"){
            float distance=pathCreator.path.GetClosestDistanceAlongPath(transform.position);
            transform.localRotation=pathCreator.path.GetRotationAtDistance(distance);
            transform.localEulerAngles= new Vector3 (transform.localEulerAngles.x,transform.localEulerAngles.y, 0);
            transform.position=pathCreator.path.GetClosestPointOnPath(transform.position)+new Vector3(0,2,0);
            rigidBody.isKinematic=true;
            meshCollider.isTrigger=true;
            allWheelColliders.SetActive(!true);
            playerRespawn=true;
        }
    }    
    void Update()
    {
        if(Input.GetAxis(playerClass.NameOfInputHorizontal)>0 || Input.GetAxis(playerClass.NameOfInputVertical)!=0)
            {
                allWheelColliders.SetActive(!false);
                playerRespawn=false;
                rigidBody.isKinematic=false;
                meshCollider.isTrigger=false;
            }
    }
    public void Move()
    {
        GetInput(playerClass.NameOfInputHorizontal, playerClass.NameOfInputVertical);
        playerClass.Steer(f_horizontalInput);
        if(f_verticalInput<0)
            playerClass.Brake(f_verticalInput);
        else    playerClass.Accelerate(f_verticalInput);
    }
    public void GetInput(string nameOfInputHorizontal, string nameOfInputVertical)
    {
        f_horizontalInput = Input.GetAxis(nameOfInputHorizontal);
        f_verticalInput = Input.GetAxis(nameOfInputVertical);
    }
}