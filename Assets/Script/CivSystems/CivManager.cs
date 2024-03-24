using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

namespace Assets.Core
{
    public class CivManager : MonoBehaviour
    {
        public static CivManager instance;

        //public StarSysManager starSysManager;

        public List<CivSO> civSOListSmall;

        public List<CivSO> civSOListMedium;

        public List<CivSO> civSOListLarge;

        public List<CivData> civDataList;

        //public GameObject civilizationPrefab;
        public CivData localPlayer;

        private void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else
            { 
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public CivData CreateLocalPlayer()
        {
            localPlayer = GetCivDataByName("FEDERATION");

            //localPlayer = Instantiate(civilizationPrefab).GetComponent<CivData>();
            //InitializeCivDataFromCivSO(localPlayer, civSOListSmall[0]); // local player first in list ****
            //civilizationPrefab.GetComponent<CivData>(); 
            return localPlayer;
            
        }
        public void InitializeCivDataFromCivSO(CivData civData, CivSO civSO)
        {
            civData.CivInt = civSO.CivInt;
            civData.CivShortName = civSO.CivShortName;
        }

        public void CreateNewGame(int sizeGame)
        {
            if (sizeGame == 0)
            {
                CreateGameCivs(civSOListSmall);
                //FleetManager.CreateNewGameFleets(1);
            }
            if (sizeGame == 1)
            {
                CreateGameCivs(civSOListMedium);
                //FleetManager.CreateNewGameFleets(2);
            }
            if (sizeGame == 2)
            {
                CreateGameCivs(civSOListLarge);
                //FleetManager.CreateNewGameFleets(3);
            }
        }

        public void CreateGameCivs(List<CivSO> civSOList)
        {
            civDataList = new List<CivData>();
            foreach (var civSO in civSOList)
            {
                CivData data = new CivData();
                data.CivInt = civSO.CivInt;
                data.CivEnum = civSO.CivEnum;
                data.CivLongName = civSO.CivLongName;
                data.CivShortName = civSO.CivShortName;
                data.TraitOne = civSO.TraitOne;
                data.TraitTwo = civSO.TraitTwo;
                data.CivImage = civSO.CivImage;
                data.Insignia = civSO.Insignia;
                data.Population = civSO.Population;
                data.Credits = civSO.Credits;
                data.TechPoints = civSO.TechPoints;
                //wip add more fields
                civDataList.Add(data);
                
            }
            StarSysManager.instance.CreateGameSystems(civSOList);

        }

        public CivData resultInGameCivData;

        public CivData GetCivDataByName(string shortName)
        {

            CivData result = null;


            foreach (var civ in civDataList)
            {

                if (civ.CivShortName.Equals(shortName))
                {
                    result = civ;
                }


            }
            return result;

        }
        public void OnNewGameButtonClicked(int gameSize)
        {
            CreateNewGame(gameSize);

        }

        public void GetCivByName(string civname)
        {
            resultInGameCivData = GetCivDataByName(civname);

        }
    }
}
