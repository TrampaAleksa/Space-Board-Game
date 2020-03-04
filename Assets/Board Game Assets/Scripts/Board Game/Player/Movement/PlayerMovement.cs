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

    private void OnTriggerEnter(Collider other)
    {
        movementHandler = InstanceManager.Instance.Get<MovementHandler>();
        if (other.tag == "NextField")
        {
            other.tag = "Untagged";
            movementHandler.MoveToNextField(gameObject);
        }
        else if (other.tag == "LastField")
        {
            other.tag = "Untagged";
            FieldEffect[] effects = currentPlayerField.GetComponents<FieldEffect>();
            foreach (var effect in effects) effect.TriggerEffect();
            // effects[0].TooltipDisplay();
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetDirection = currentPlayerField.transform.position + (Vector3.up * 0.5f) + currentPlayerField.transform.forward - transform.position;

        float singleStep = rotationSpeed * Time.deltaTime;

        Quaternion _rot = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, singleStep);
        // Maybe you can disable / enable the movement script when needed to be used so that you don't have the constant position update
        transform.position = Vector3.MoveTowards(transform.position, positionToTravelTo + (Vector3.up * 0.5f), movementSpeed * Time.deltaTime);
    }
}