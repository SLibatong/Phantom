using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    private bool b;
    public Transform cameraTransform;
    public Vector3 vector;
    private Rigidbody rb;

    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        b = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && b)
        {
            transform.parent = cameraTransform;
            transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.isKinematic = true;
            //Debug.Log(1);
            playerInput.Player.Disable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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
