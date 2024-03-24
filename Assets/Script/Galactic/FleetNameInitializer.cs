using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
using UnityEditor;

public class FleetNameInitializer : MonoBehaviour
{
    public FleetManager fleetManager;

    public void GetSavedGameFleetNames(CivEnum civ, string name)
    {
        // get samed fleet names here
        FleetNamesSO retrievedNames = fleetManager.FindFleetName(civ,name);
        Debug.Log( retrievedNames.intName);

    }
    public FleetNamesSO CreateFleetNamesSO(CivEnum civEnum, int nameInt)
    {
        FleetNamesSO newNameSO = ScriptableObject.CreateInstance<FleetNamesSO>();
        newNameSO.CivEnum = civEnum;

        newNameSO.intName = nameInt;


        // Save as an asset if needed
        AssetDatabase.CreateAsset(newNameSO, "Assets/Resources/FleetNamesSO");

        return newNameSO;
    }
}
