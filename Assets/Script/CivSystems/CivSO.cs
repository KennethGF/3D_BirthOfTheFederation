using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Core
{
    [CreateAssetMenu(fileName = "CivSO", menuName = "CivSO")]
    public class CivSO : ScriptableObject
    {
        public int CivInt;
        public CivEnum CivEnum;
        public string CivShortName;
        public string CivLongName;
        public string CivHomeSystem; //best way???
        public string TraitOne;
        public string TraitTwo;
        public Sprite CivImage;
        public Sprite Insignia;
        public int Population;
        public int Credits;
        public int TechPoints;
        //public string Description;
    }
}


