using GalaxyMap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core
{
    public class FleetController : MonoBehaviour
    {
        //Fields
        public FleetData fleetData;


        void Update()
        {
            if (fleetData != null)
            {
                fleetData.location = transform.position;
            }
        }
        public void UpdateWarpFactor(int delta)
        {
            fleetData.warpFactor += delta;
        }
        private void OnEnable()
        {
            if (fleetData != null)
                fleetData.location = transform.position;
        }
    }
}
