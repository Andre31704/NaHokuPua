using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolController : MonoBehaviour
{
    public bool isKneeling { get; private set; }

    public void CheckBoolValue()
    {
       isKneeling = true;
    }
}
