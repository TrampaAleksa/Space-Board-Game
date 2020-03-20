using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRankInit : MonoBehaviour, IBoardStateInitializer
{
    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        //ranks should be reset to 0 when leaving the board
        playerState.rank = 0;
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int rank = playerState.rank;
        float fuelReward = RankHandler.PrizeForRank(rank);
        InstanceManager.Instance.Get<FuelHandler>().AddFuelToPlayer(player, fuelReward, false);
    }
}
