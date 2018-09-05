using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    namespace PlayerController
    {
        [System.Serializable]
        public class GroundSystem 
        {
            [SerializeField]
            Color rayColor;
            [SerializeField, Range(0.1f, 10f)]
            float rayLenght;
            [SerializeField]
            LayerMask groundLayer;

            public RaycastHit2D CheckGround(Transform transform)
            {
                
                return Physics2D.Raycast(transform.position, -transform.up, rayLenght, groundLayer);
            }

            public void DrawRay(Transform transform)
            {
                Gizmos.color = rayColor;
                Gizmos.DrawRay(transform.position, -transform.up * rayLenght);
            }
        }
    }
}
