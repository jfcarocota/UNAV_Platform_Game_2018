using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

public class TouchTest : MonoBehaviour
{

    private void Update()
    {
        //if (ControlSystem.Tch_tap) Debug.Log("Tap");
        //if (ControlSystem.Tch_moved) Debug.Log("moved");
        //if (ControlSystem.Tch_stationary) Debug.Log("stationary");
        //if (ControlSystem.Tch_ended) Debug.Log("ended");
        if (ControlSystem.Tch_canceled) Debug.Log("canceled");
    }
}
