using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControl
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInput.PlayerActions playerMove;
        private PlayerMotor motor;
        private PlayerLook look;

        // Start is called before the first frame update
        void Awake()
        {
            playerInput = new PlayerInput();
            playerMove = playerInput.Player;
            motor = GetComponent<PlayerMotor>();
            look = GetComponent<PlayerLook>();
        }

        // Update is called once per frame
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
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }
    }
}
