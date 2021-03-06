﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : GenericObjectArray
{
    public GameObject random;
    void Start()
    {
        InstanceManager.Instance.Get<SelectionHandler>().SetCurrentMember(0);
    }

    public GameObject GetCurrentPlayer()
    {
        return CurrentMember();
    }

    public GameObject SetToNextPlayer()
    {
        SetToNextMember();
        InstanceManager.Instance.Get<SelectionHandler>().SetCurrentMember(CurrentMemberIndex);
        return CurrentMember();
    }

    public GameObject SetCurrentPlayer(int index)
    {
        InstanceManager.Instance.Get<SelectionHandler>().SetCurrentMember(CurrentMemberIndex);
        return SetCurrentMember(index);
    }

    public GameObject GetPlayerWithIndex(int index)
    {
        return MemberWithIndex(index);
    }
   
}
