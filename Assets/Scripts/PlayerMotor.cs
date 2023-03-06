using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Phantom
{
    public class PlayerMotor : MonoBehaviour
    {
        private Rigidbody rb;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //recieve inputs from InputManager
        public void ProcessMove(Vector2 input)
        {
            //movement
            Vector3 movement = new Vector3(input.x, 0, input.y);
            rb.velocity = transform.TransformDirection(movement * speed * Time.deltaTime);
        }
    }
}
