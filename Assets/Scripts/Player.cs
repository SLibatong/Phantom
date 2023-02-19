using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMan
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        PlayerControl input;

        private Rigidbody rb;
        public float moveSpeed;
        private Vector2 moveValue;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            input.EnableInput();
        }

        private void OnEnable()
        {
            input.onMove += Move;
            input.onStopMove += StopMove;
        }

        private void OnDisable()
        {
            input.onMove -= Move;
            input.onStopMove -= StopMove;
        }

        private void Move(Vector2 moveValue)
        {
            this.moveValue = moveValue.normalized;
        }

        private void StopMove()
        {

        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector3(moveValue.x * moveSpeed, 0, moveValue.y * moveSpeed);
        }

    }
}

