using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class PlayerTransform : MonoBehaviour
    {
        private bool inRealWorld;
        private Vector3 currentPosition;

        SwitchPlayer switchPlayer = new SwitchPlayer();

        void Update()
        {
            inRealWorld = DetectPlayer(switchPlayer.player1);
            if (inRealWorld)
            {
                currentPosition = new Vector3(switchPlayer.player1.transform.position.x, switchPlayer.player1.transform.position.y,
                    switchPlayer.player1.transform.position.z);
            }
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