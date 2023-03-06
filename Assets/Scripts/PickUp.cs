using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Phantom
{
    public class PickUp : MonoBehaviour
    {
        private bool b;
        public Transform cameraTransform;
        public Transform itemsTransform;
        public Vector3 vector;
        private Rigidbody rb;
        public static bool isPause;
        private Vector3 originalVector;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            b = false;
            isPause = false;
            originalVector = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && b)
            {
                transform.parent = cameraTransform;
                transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                rb.isKinematic = true;
                isPause = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                isPause = false;
                transform.parent = itemsTransform;
                transform.localPosition = new Vector3(originalVector.x, originalVector.y, originalVector.z);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                b = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                b = false;
            }
        }
    }
}