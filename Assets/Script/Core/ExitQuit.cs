using UnityEngine;
using System.Collections;
using Assets.Core;


namespace Assets.Core
{
    public class ExitQuit : MonoBehaviour
    {
        //public static ExitQuit Instance { get; private set; }
        //private void Awake()
        //{
        //    Instance = this;
        //}
        public void ExitTheGame()
        {
           // UnityEditor.EditorApplication.isPlaying = false; // (this works in editor play mode but NOT for a BUILD!!)
           OnApplicationQuit();
           Application.Quit(); // Only works in a BUILD and not in editor pay mode!
        }
        void Update()
        {
            //if (Input.GetKey("escape"))
            //{
            //    Application.Quit();
            //}
        }
        void OnApplicationQuit() // save string in Player Pref Value on quits
        {
            PlayerPrefs.SetString("QuitTime", "The application last closed at: " + System.DateTime.Now);
        }
    }
    public class PreventQuit : MonoBehaviour // you this to ask about save game.....
    {
        public bool preventAppQuit;
        void Start()
        {
            Application.wantsToQuit += WantsToQuit;
        }
        bool WantsToQuit()
        {
            return !preventAppQuit;
        }
    }
    
}
