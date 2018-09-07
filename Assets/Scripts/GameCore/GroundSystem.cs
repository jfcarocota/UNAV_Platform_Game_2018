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
            [SerializeField]
            Vector2 startPosition;

            public Vector2 StartPosition
            {
                get
                {
                    return startPosition;
                }
            }

            public RaycastHit2D CheckGround(Transform transform)
            {
                
                return Physics2D.Raycast((Vector2)transform.position + startPosition, -transform.up, rayLenght, groundLayer);
            }

            public void DrawRay(Transform transform)
            {
                Gizmos.color = rayColor;
                Gizmos.DrawRay((Vector2)transform.position + startPosition, -transform.up * rayLenght);
            }
        }
    }
}
