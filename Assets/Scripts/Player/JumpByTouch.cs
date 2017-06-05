using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    namespace Movement
    {
        [RequireComponent(typeof(Rigidbody2D))]
        public class JumpByTouch : MonoBehaviour
        {
            #region Init
            [Range(50, 250.0f)]
            [SerializeField]
            private float heightForce = 150.0f;
            [Range(10.0f, 100.0f)]
            [SerializeField]
            private float widthForce = 30.0f;

            private Rigidbody2D rb2D = null;
            private enum JumpDirection
            {
                left,
                right
            }
            private JumpByTouch jumpDirection;

#if UNITY_IOS || UNITY_ANDROID
            [SerializeField]
            private float clickRate = 0.25f;
            private float nextClick = 0.0f;
#endif 
            #endregion

            #region MonoBehaviours
            private void Start()
            {
                rb2D = GetComponent<Rigidbody2D>();
            }

            private void FixedUpdate()
            {
                InputFiler();
            }
            #endregion

            #region Work Method(s)
            private void InputFiler()
            {
#if UNITY_EDITOR
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ResetVelocity();
                    MoveRigidBody(JumpDirection.right);
                }
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ResetVelocity();
                    MoveRigidBody(JumpDirection.left);
                }
#elif UNITY_IOS || UNITY_ANDROID
                if (Time.time > nextClick) // ngăn user chạm liên tục vào màn hình
                {
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.position.x > Screen.width / 2)
                        {
                            ResetVelocity();
                            MoveRigidBody(JumpDirection.right);
                        }
                        else if (touch.position.x < Screen.width / 2)
                        {
                            ResetVelocity();
                            MoveRigidBody(JumpDirection.left);
                        }

                        nextClick = Time.time + clickRate; // ngăn user chạm liên tục vào màn hình
                    }
                }
#endif
            }

            private void MoveRigidBody(JumpDirection jumpDirection)
            {
                if (jumpDirection == JumpDirection.left)
                {
                    rb2D.AddForce(new Vector2(-widthForce, heightForce));
                }
                else // jump right
                {
                    rb2D.AddForce(new Vector2(widthForce, heightForce));
                }
            }

            /// <summary>
            /// Reset lại gia tốc, ngăn player nhảy quá mạnh
            /// </summary>
            private void ResetVelocity()
            {
                rb2D.velocity = new Vector2(0.0f, 0.0f);
            }
        }
        #endregion
    }
}


