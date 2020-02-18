using UnityEngine;

public class FieldHandler : GenericObjectArray, IBoardState
{
    private void Awake()
    {
        InitializeFields();
    }

    public void SetCurrentField(Field fieldToSetTo, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        Field originalField = playerMovement.currentPlayerField;
        originalField.RemovePlayerFromField(player);

        fieldToSetTo.AddPlayerToField(player);
    }

    public void TeleportPlayerToField(GameObject player, Field field)
    {
        SetCurrentField(field, player);
        player.GetComponent<PlayerMovement>().transform.position = player.GetComponent<PlayerMovement>().positionToTravelTo;
    }

    public void SwapTwoPlayers(PlayerMovement playerMovement1, PlayerMovement playerMovement2)
    {
        Field originalField1 = playerMovement1.currentPlayerField;
        Field originalField2 = playerMovement2.currentPlayerField;

        originalField1.RemovePlayerFromField(playerMovement1.gameObject);
        originalField2.RemovePlayerFromField(playerMovement2.gameObject);

        originalField2.AddPlayerToField(playerMovement1.gameObject);
        originalField1.AddPlayerToField(playerMovement2.gameObject);
    }

    public int DistanceBetweenTwoFields(Field field1, Field field2)
    {
        //Note -- If the player tries to teleport ahead of the finish line or before the finish line print
        //a message saying that he can't do that (the difference between the last index and first index is very big so he
        // wont be able to teleport even if he wanted to).
        return Mathf.Abs(field1.IndexInPath - field2.IndexInPath);
    }

    public void InitializeFields()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Field");
        int i = 0;
        foreach (var field in gameObjects)
        {
            field.tag = "Untagged";
            field.AddComponent<Field>();
            field.GetComponent<Field>().InitialSetUpField(i);
            i++;
        }
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int index = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].pathIndex
                = player.GetComponent<PlayerMovement>().currentPlayerField.IndexInPath;
            print("Saved players position index: " + index);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int index = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].pathIndex;
            MemberWithIndex(index).GetComponent<Field>().AddPlayerToField(player);
            i++;
        }
    }
}