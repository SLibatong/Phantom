using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace PlayerMan
{
    [CreateAssetMenu(menuName = "Player Control")]
    public class PlayerControl : ScriptableObject, Man.IPlayerActions
    {
        private bool touch = false;
        private Rigidbody rb;
        public float moveSpeed;
        private float moveX, moveY;

        private Man manInput;
        public event UnityAction<Vector2> onMove = delegate { };
        public event UnityAction onStopMove = delegate { };

        private void OnEnable()
        {
            manInput = new Man();

            manInput.Player.SetCallbacks(this);
        }

        private void OnDisable()
        {
            manInput.Player.Disable();
        }

        public void EnableInput()
        {
            manInput.Player.Enable();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                onMove.Invoke(context.ReadValue<Vector2>());
            }

            if(context.phase == InputActionPhase.Canceled)
            {
                onStopMove.Invoke();
            }
        }

        public void OnPickup(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCheck(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}

