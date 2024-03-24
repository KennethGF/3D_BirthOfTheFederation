using UnityEngine;
using UnityEditor;
using System.IO;

public class ShipSOImporter : EditorWindow
{
    [MenuItem("Tools/Import ShipSO CSV")]
    public static void ShowWindow()
    {
        GetWindow<ShipSOImporter>("ShipSO CSV Importer");
    }

    private string filePath = "shipROM.csv";

    void OnGUI()
    {
        GUILayout.Label("ShipSO CSV Importer", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("CSV File Path", filePath);

        if (GUILayout.Button("Import CSV"))
        {
           

            //Output the Game data path to the console
            Debug.Log("dataPath : " + Application.dataPath);
            ImportCSV(filePath);
        }
    }

    private static void ImportCSV(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] fields = line.Split(',');

            if (fields.Length == 8) // Ensure there are enough fields
            {
                ShipSO ship = CreateInstance<ShipSO>();
                ship.Tech = fields[0];
                ship.Class = fields[1];
                ship.Key = fields[2];
                ship.ShieldMaxHealth = int.Parse(fields[3]);
                ship.HullMaxHealth = int.Parse(fields[4]);
                ship.TorpedoDamage = int.Parse(fields[5]);
                ship.BeamDamage = int.Parse(fields[6]);
                ship.Cost = int.Parse(fields[7]);

                string assetPath = $"Assets/ShipSO_{ship.Tech}_{ship.Key}.asset";
                AssetDatabase.CreateAsset(ship, assetPath);
                AssetDatabase.SaveAssets();
            }
        }

        Debug.Log("ShipSO Import Complete");
    }
}
