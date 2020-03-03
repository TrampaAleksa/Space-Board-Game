using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankHandler : MonoBehaviour, IBoardState
{
    public float rewardPerRank = 5f;

    public void SaveState()
    {
        //ranks should be reset to 0 when leaving the board
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].rank = 0;
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            int rank = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].rank;
            float fuelReward = PrizeForRank(rank);
            InstanceManager.Instance.Get<FuelHandler>().AddFuelToPlayer(player, fuelReward);
            i++;
        }
    }

    public float PrizeForRank(int rank)
    {
        return (4 - rank) * rewardPerRank;
    }
}