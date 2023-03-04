using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private bool b = true;

    private void Awake()
    {
        camera1.SetActive(b);
        camera2.SetActive(!b);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Switch the two different world
        if (Input.GetMouseButtonDown(1))
        {
            camera1.SetActive(!b);
            camera2.SetActive(b);
            b = !b;
        }
    }
}
