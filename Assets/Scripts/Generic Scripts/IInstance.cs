using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstance
{
    GameObject InitializeInAwake();
    GameObject InitializeInStart();
}
