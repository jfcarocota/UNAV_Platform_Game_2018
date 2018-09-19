using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchJoystick : MonoBehaviour
{
    Vector2 tch_axis;

    public Vector2 Tch_axis
    {
        get
        {
            return tch_axis;
        }

        set
        {
            tch_axis = value;
        }
    }
}
