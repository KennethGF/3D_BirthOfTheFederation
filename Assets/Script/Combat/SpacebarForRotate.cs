using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Core;
using System;

namespace Assets.Core
{
    public class SpacebarForRotate : MonoBehaviour
    {
        public float dealySeconds = 6f;
        //public float resetTimer = 6f;

        public TMP_Text spacebarRotate;
        private bool reset = true;
        void Start()
        {
            spacebarRotate.text = "Red Alert";
        }
        void Update()
        {

            if (reset)
            {
                dealySeconds -= Time.deltaTime;
                if (dealySeconds <= 3 && dealySeconds > -2)
                {
                    spacebarRotate.text = "Hold down the spacebar to rotate with mouse";
                }
                else if (dealySeconds > 3)
                {
                    spacebarRotate.text = "Red Alert";
                }
                else
                {
                    spacebarRotate.text = "Red Alert";
                    reset = false;
                }
            }

        }

    }
}
