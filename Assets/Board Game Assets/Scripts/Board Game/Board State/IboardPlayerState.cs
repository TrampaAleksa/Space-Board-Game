using UnityEngine;

public interface IBoardPlayerState
{
    void SavePlayerState(GameObject player, PlayerBoardState playerState);

    void SetupPlayerState(GameObject player, PlayerBoardState playerState);
}