using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameCore
{
    namespace PlayerController
    {
         
        public class ControlSystem
        {

            public static Vector2 Axis
            {
                get
                {
                    return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                }
            }

            public static bool Btn_jump
            {
                get
                {
                    return Input.GetButtonDown("Jump");
                }
            }

            public static bool Tch_tap
            {
                get
                {
                    return Input.touchCount == 1 
                            ? Input.touches[0].phase == TouchPhase.Began
                            : false;
                }
            }

            public static bool Tch_moved
            {
                get
                {
                    return Input.touchCount == 1
                            ? Input.touches[0].phase == TouchPhase.Moved
                            : false;
                }
            }


            public static bool Tch_stationary
            {
                get
                {
                    return Input.touchCount == 1
                            ? Input.touches[0].phase == TouchPhase.Stationary
                            : false;
                }
            }

            public static bool Tch_ended
            {
                get
                {
                    return Input.touchCount == 1
                            ? Input.touches[0].phase == TouchPhase.Ended
                            : false;
                }
            }

            public static bool Tch_canceled
            {
                get
                {
                    return Input.touchCount == 1
                            ? Input.touches[0].phase == TouchPhase.Canceled
                            : false;
                }
            }
        }


    }
}