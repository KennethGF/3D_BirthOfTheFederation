using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Assets.Core
{
    public class SaveLoadManager : MonoBehaviour
    {
        public static SaveLoadManager instance;

        public static SaveData activeSave; // static SaveData, is this static a problem???

        public static bool hasLoaded = false;

        private void Awake()
        {
            instance = this;
           // Load();
        }
        public static void Save()
        {
            string dataPath = Application.persistentDataPath;

            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName +".save", FileMode.Create);
            serializer.Serialize(stream, activeSave);
            stream.Close();

            Debug.Log("Saved");
        }
        public static void Load()
        {
            //string dataPath = Application.persistentDataPath;
            //if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
            //{
            //    var serializer = new XmlSerializer(typeof(SaveData));
            //    var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            //    activeSave = serializer.Deserialize(stream) as SaveData;
            //    stream.Close();
            //    hasLoaded = true;
            //    Debug.Log("Loaded");
            //}
        }
        public void DeleteSaveData() // ToDo: connect this to something, when there is a saved game menu
        {
            string dataPath = Application.persistentDataPath;
            if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
            {
                File.Delete(dataPath + "/" + activeSave.saveName + ".save");
                Debug.Log("Deleted Save Data");
            }
        }
    }
    [System.Serializable]
    public class SaveData
    {
        public string saveName;
        //[SerializeField]
        // ToDo: Save game elements: civ, systems, ships, tech and everything else I did not think of here.
    }
}
