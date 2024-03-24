using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


namespace Assets.Core
{
    //public enum FleetNames
    //{
    //    st,
    //    nd,

    //}
    public class FleetManager : MonoBehaviour
    {
        public List<FleetSO> fleetSOListSmall;

        public List<FleetSO> fleetSOListMedium;

        public List<FleetSO> fleetSOListLarge;

        public List<FleetData> fleetDataList;

        public Dictionary<CivEnum, List<FleetNamesSO>> allFleetNames = new Dictionary<CivEnum, List<FleetNamesSO>>();

        public void CreateNewGameFleets(int gameSize)
        {
            if(gameSize == 1)
            {
                CreateFleetsBySOLists(fleetSOListSmall) ;
            }
            if (gameSize == 2)
            {
                CreateFleetsBySOLists(fleetSOListMedium);
            }
            if (gameSize == 3)
            {
                CreateFleetsBySOLists(fleetSOListLarge);
            }
        }

        public void CreateFleetsBySOLists(List<FleetSO> listFleetSO)
        {
            foreach (var fleetSO in listFleetSO)
            {
                FleetData fleet = new FleetData();
                fleet.civIndex = fleetSO.CivIndex;
                fleet.civOwnerEnum = fleetSO.CivOwnerEnum;
                int fleetIntName = 0;
                fleetIntName = GetUniqueFleetName(fleet.civOwnerEnum, fleetIntName);
                FleetNameInitializer newFleetName = new FleetNameInitializer();
                FleetNamesSO myFleetNameSO = newFleetName.CreateFleetNamesSO(fleet.civOwnerEnum, fleetIntName);

                if (allFleetNames.TryGetValue(fleet.civOwnerEnum, out listSONames))
                {
                    listSONames.Add(myFleetNameSO);
                }
                fleet.fleetName = "fleetIntName";
                fleetDataList.Add(fleet);
            }
        }
        public FleetData resultFleetData;
        private List<FleetNamesSO> listSONames;

        public void AddFleetName(CivEnum civ, List<FleetNamesSO> newNameSO)
        {
            allFleetNames.Add(civ, newNameSO);
        }

        public FleetNamesSO FindFleetName(CivEnum civ, string nameSO)
        {
            List<FleetNamesSO> myList = new List<FleetNamesSO>();
            myList = allFleetNames[civ];
            return myList.Find(data => data.name == nameSO);
        }

        public int GetUniqueFleetName(CivEnum civEnum, int nameInt)
        {
            int intName = 0;
            if (allFleetNames.TryGetValue(civEnum, out listSONames))
            {

                for(int i = 0; i < 1000; i++) 
                {
                    if (listSONames[i].intName != nameInt)
                    {
                        intName =i;
                       //listSONames.Add
                        break;
                    }
                }

            }
            
            return intName;
        }

        public FleetData GetFleetDataByName(string fleetName)
        {

            FleetData result = null;


            foreach (var fleet in fleetDataList)
            {

                if (fleet.fleetName.Equals(fleetName))
                {
                    result = fleet;
                }
            }
            return result;

        }
        //public void OnNewGameButtonClicked(int gameSize)
        //{
        //    CreateNewGame(gameSize);

        //}

        public void GetFleetByName(string fleetName)
        {
            resultFleetData = GetFleetDataByName(fleetName);

        }

    }
}