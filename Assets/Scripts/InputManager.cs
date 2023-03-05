using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Phantom
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInput.PlayerActions playerMove;
        private PlayerInput.GameSystemActions systemInput;
        private PlayerMotor motor;
        private PlayerLook look;
        private bool ispause = false;

        void Awake()
        {
            playerInput = new PlayerInput();
            playerMove = playerInput.Player;
            systemInput = playerInput.GameSystem;
            motor = GetComponent<PlayerMotor>();
            look = GetComponent<PlayerLook>();
        }

        void FixedUpdate()
        {
            //tell playermotor to move using the value from our movement action
            motor.ProcessMove(playerMove.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            look.ProcessLook(playerMove.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            playerInput.Enable();
            systemInput.Pause.performed += GamePause;
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        public void GamePause(InputAction.CallbackContext ctx)
        {
            if (ctx.phase == InputActionPhase.Performed && !ispause)
            {
                playerMove.Disable();
                ispause = true;
            }
            else if(ctx.phase == InputActionPhase.Performed && ispause)
            {
                playerMove.Enable();
                ispause = false;
            }
        }
    }
}
