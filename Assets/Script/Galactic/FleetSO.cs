
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace Assets.Core
{
    [CreateAssetMenu(menuName = "Galaxy/FleetSO")]
    public class FleetSO : ScriptableObject
    {
        public int CivIndex;
        public Sprite Insignia;
        public CivEnum CivOwnerEnum;
        public float DefaultWarpFactor = 0f;
        public FleetNamesSO Name;

    }
}




