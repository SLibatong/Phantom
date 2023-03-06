using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class PlayerLook : MonoBehaviour
    {
        public Camera mainCamera;
        private float rotationX = 0f;
        public float viewScale;
        public float sensitivityX, sensitivityY;

        public void ProcessLook(Vector2 input)
        {
            //camera look up and down
            rotationX -= (input.y * Time.deltaTime) * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, -viewScale, viewScale);
            //apply this to camera transform
            mainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            //rotate player to look left and right
            transform.Rotate(Vector3.up * (input.x * Time.deltaTime) * sensitivityX);
        }
    }
}
