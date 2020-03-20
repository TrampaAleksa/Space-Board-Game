using UnityEngine;

public interface IBoardStateInitializer
{
    void SavePlayerState(GameObject player, PlayerBoardState playerState);

    void SetupPlayerState(GameObject player, PlayerBoardState playerState);
}