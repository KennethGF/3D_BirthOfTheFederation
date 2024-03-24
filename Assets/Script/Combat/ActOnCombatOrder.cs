using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Core
{
    public class ActOnCombatOrder : MonoBehaviour
    {
        public static List<GameObject> FriendShips = new List<GameObject>();  // updated to current combat
        public static List<GameObject> EnemyShips = new List<GameObject>();
        public static List<GameObject> CombatObjects = new List<GameObject>();

        public void CombatOrderAction(Orders order, List<GameObject> daFriends, List<GameObject> daEnemies) // GameManager Orders updated by toggle in CombatmMenu through CombatOrderSeleciton.cs
        {
            FriendShips = daFriends;
            EnemyShips = daEnemies;

            for (int i = 0; i < daFriends.Count; i++)
            {
                CombatObjects.Add(daFriends[i]);
            }

            for (int i = 0; i < daEnemies.Count; i++)
            {
                CombatObjects.Add(daEnemies[i]);
            }

            switch (order)
            {
                case Orders.Engage:
                    EngageOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Engage;
                    // currently using InstantiateCombatShips to setup ship entry by order then this section will be for during combat running
                    break;
                case Orders.Rush:
                    RushOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Rush;
                    break;
                case Orders.Formation:
                    FormationOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Formation;
                    break;
                case Orders.Retreat:
                    RetreatOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.Retreat;
                    break;
                case Orders.ProtectTransports:
                    ProtectTransportsOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.ProtectTransports;
                    break;
                case Orders.TargetTransports:
                    TargetTransportsOrder();
                    //GameManager.Instance.instantiateCombatShips.order = Orders.TargetTransports;
                    break;
                default:
                    break;
            }
        }
        private void EngageOrder()
        {            
            // instantiation locations set in InstantiateCombatShips based on CombatOrderSelection.cs / UI
        }
        private void RushOrder() { }
        private void RetreatOrder() { }
        private void FormationOrder() { }
        private void ProtectTransportsOrder() { }
        private void TargetTransportsOrder() { }
    }
}
