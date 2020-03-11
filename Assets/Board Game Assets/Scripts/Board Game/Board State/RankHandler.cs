using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankHandler : MonoBehaviour, IBoardPlayerState
{
    public float rewardPerRank = 5f;

    public void SavePlayerState(GameObject player, PlayerBoardState playerState)
    {
        //ranks should be reset to 0 when leaving the board
        playerState.rank = 0;
    }

    public void SetupPlayerState(GameObject player, PlayerBoardState playerState)
    {
        int rank = playerState.rank;
        float fuelReward = PrizeForRank(rank);
        InstanceManager.Instance.Get<FuelHandler>().AddFuelToPlayer(player, fuelReward);
    }

    public float PrizeForRank(int rank)
    {
        return (4 - rank) * rewardPerRank;
    }
}