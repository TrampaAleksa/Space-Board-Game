using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PathCreation;

public partial class PlayerController : MonoBehaviour
{
    public GameObject allWheelColliders;
    public Rigidbody rigidBody;
    public MeshCollider meshCollider;
    public CameraFollowController cameraFollowController;
    public PlayerClass playerClass;
    public static int i = 0;
    private float f_horizontalInput;
    private float f_verticalInput;
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
        playerClass = new PlayerClass(gameObject, i, GameManager.Instance.ReturnName(i++), maxSteerAngle, motorForce, maximumRotation);
        playerClass.Text.text = "Speed";
    }
    private void FixedUpdate()
    {
        if(startGame){
            Move();
        }
        playerClass.CountSpeed();
         print(startGame);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
            FinishGame();
        if (other.tag == "DeathLine"){
            float distance=pathCreator.path.GetClosestDistanceAlongPath(transform.position);
            transform.localRotation=pathCreator.path.GetRotationAtDistance(distance);
            transform.localEulerAngles= new Vector3 (transform.localEulerAngles.x,transform.localEulerAngles.y, 0);
            transform.position=pathCreator.path.GetClosestPointOnPath(transform.position)+new Vector3(0,2,0);
            rigidBody.isKinematic=true;
            meshCollider.isTrigger=true;
            allWheelColliders.SetActive(false);
            playerClass.Brake(0);
            startGame=false;
        }
    }    
    void Update()
    {
        if(Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                startGame=true;
                //rigidBody.isKinematic=false;
                //meshCollider.isTrigger=false;
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
    private void FinishGame()
    {
        playerClass.Distance=pathCreator.path.GetClosestDistanceAlongPath(transform.localPosition);
        GameManager.Instance.PlayerDeath(playerClass, cameraFollowController);
        gameObject.SetActive(false);
        playerClass.Text.text = "SPECTATE";
    }
}