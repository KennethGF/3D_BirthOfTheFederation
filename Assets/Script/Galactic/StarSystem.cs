using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core;

namespace GalaxyMap
{
    public class StarSystem : MonoBehaviour
    {
        public StarSysData starSysData;
        public Text nameText;
        public Text descriptionText;
        public Image artworkImage;

        private void Start()
        {
            if (starSysData == null)
            {
                nameText.text = starSysData.SysName;
                //descriptionText.text = starSysData.description;
                //artworkImage.sprite = starSysData.starSprit;
            }
        }
        private void OnEnable()
        {
            if (starSysData != null)
            {
               // starSysData.location = transform.position;
            }
        }

        void Update()
        {
            if (starSysData != null)
            {
                //starSysData.location = transform.position;
            }
        }
        private void OnDisable()
        {
           // starSysData.ResetData();
        }
    }
}