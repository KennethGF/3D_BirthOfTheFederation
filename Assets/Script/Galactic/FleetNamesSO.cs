using Assets.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New FleetNamesSO", menuName = "Feet Names")]
public class FleetNamesSO : ScriptableObject
{
    public CivEnum CivEnum;
    public int intName;

}
