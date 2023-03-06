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
        private bool gamePause = true;

        void Awake()
        {
            playerInput = new PlayerInput();
            playerMove = playerInput.Player;
            systemInput = playerInput.GameSystem;
            motor = GetComponent<PlayerMotor>();
            look = GetComponent<PlayerLook>();
        }

        private void Update()
        {
            bool isPause = PickUp.isPause;
            PickUpPause(isPause);
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
            if (ctx.phase == InputActionPhase.Performed && gamePause)
            {
                playerMove.Disable();
                gamePause = !gamePause;
            }
            else if(ctx.phase == InputActionPhase.Performed && !gamePause)
            {
                playerMove.Enable();
                gamePause = !gamePause;
            }
        }

        public void PickUpPause(bool b)
        {
            if (b)
            {
                playerMove.Disable();
            }
            else
            {
                playerMove.Enable();
            }
        }
    }
}
