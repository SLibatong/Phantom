using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class SwitchPlayer : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;
        protected bool b1 = true, b2 = true;
        public float delayTime;
        protected bool isAnim = false;
        private Animator anim;

        private bool inRealWorld;
        private void Awake()
        {
            player1.SetActive(b1);
            player2.SetActive(!b1);
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            //Switch the two different world
            if (Input.GetMouseButtonDown(1) && b2)
            {
                isAnim = true;
                b2 = !b2;
                Invoke("SwitchScene", delayTime);
            }

            inRealWorld = DetectPlayer(player1);
            if (inRealWorld)
            {

            }
        }

        private void FixedUpdate()
        {
            // start left hand turn on/off watch animation
            if (isAnim)
            {
                anim.SetBool("isOn", b1);
            }
        }

        //Swicth camera
        private void SwitchScene()
        {
            player1.SetActive(!b1);
            player2.SetActive(b1);
            b1 = !b1;
            b2 = !b2;
            isAnim = false;
        }

        private bool DetectPlayer(GameObject obj)
        {
            if (obj.activeSelf == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
