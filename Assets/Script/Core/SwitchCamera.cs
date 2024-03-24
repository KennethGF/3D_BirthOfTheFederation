using Assets.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core
{
    public class SwitchCamera : MonoBehaviour
    {
        public GameObject camera_UI;
        public GameObject camera_MainMenu;
        public GameObject camera_WarpSpeed;
        public GameObject camera_Whatever;

        //ToDo create empty gameobject and attach this script to it, drop cameras into public slots.
        void Update()
        {
            if (GameManager.Instance._statePassedCombatInit) // || GameManager.Instance._statePassedCombatInitLeft)
            {
                camera_UI.SetActive(true);
                camera_MainMenu.SetActive(false);
                camera_WarpSpeed.SetActive(false);
                camera_Whatever.SetActive(false);
            }
            else if (true)
            {
                camera_UI.SetActive(false);
                camera_MainMenu.SetActive(true);
                camera_WarpSpeed.SetActive(false);
                camera_Whatever.SetActive(false);
            }
        }
    }
}
