using UnityEngine;

public class PlayerMovement : Player
{
    private MovementHandler movementHandler;

    [SerializeField]
    public Vector3 positionToTravelTo;

    public float rotationSpeed = 30f;

    [SerializeField]
    public float movementSpeed = 15f;

    [SerializeField]
    public int spacesToMove = 0;

    private void Start()
    {
        //InstanceManager.Instance.Get<FieldHandler>().
    }

    private void OnTriggerEnter(Collider other)
    {
        movementHandler = InstanceManager.Instance.Get<MovementHandler>();
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            if (movementHandler.moveForward)
                movementHandler.MoveToNextField(gameObject);
            else movementHandler.MoveToPreviousField(gameObject);
        }
        else if (other.tag == "LastField")
        {
            other.tag = "Untagged";
            //FieldEffect[] effects = currentPlayerField.GetComponents<FieldEffect>();
            //foreach (var effect in effects) effect.TriggerEffect();
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerFieldEffects(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = currentPlayerField.transform.position
                                + (Vector3.up * 0.5f)
                                + currentPlayerField.transform.forward;
        Lerping.LerpObjectRotationToPosition(targetPosition, gameObject, rotationSpeed);
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo + (Vector3.up * 0.5f), movementSpeed * Time.deltaTime);
    }
}