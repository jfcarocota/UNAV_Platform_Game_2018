using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButtonAxis : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    enum DirectionAxis { LEFT, RIGHT};
    [SerializeField]
    DirectionAxis directionAxis;

    [SerializeField]
    TouchJoystick tchJoystick;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        switch (directionAxis)
        {
            case DirectionAxis.RIGHT:
                tchJoystick.Tch_axis = Vector2.right;
                break;
            case DirectionAxis.LEFT:
                tchJoystick.Tch_axis = Vector2.left;
                break;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        switch (directionAxis)
        {
            case DirectionAxis.RIGHT:
                tchJoystick.Tch_axis = Vector2.zero;
                break;
            case DirectionAxis.LEFT:
                tchJoystick.Tch_axis = Vector2.zero;
                break;
        }
    }
}
