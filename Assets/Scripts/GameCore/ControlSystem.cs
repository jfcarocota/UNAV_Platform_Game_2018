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
        }


    }
}