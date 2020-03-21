using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankHandler : MonoBehaviour
{
    public const float RewardPerRank = 5f;

    public static float PrizeForRank(int rank)
    {
        return (4 - rank) * RewardPerRank;
    }
}