using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardState
{
    void SaveState();
    void SetupState();
}
