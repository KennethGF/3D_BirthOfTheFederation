using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Core
{

    public class MultiPlayer : MonoBehaviour, IPointerDownHandler
    {
        Button _multiPlayerButton;

        private void Awake()
        {
            _multiPlayerButton = GetComponent<Button>();         
        }
        private void Start()
        { 
        }
        private void Update()
        {
            //var what = _isSinglePlayer.onClick;
            //{
            //    _isSinglePlayer.enabled = true;
            //    //_isMultipPlayer.enabled = false;
            //    GameManager.Instance.SinglePlayerLobbyClicked();
            //}
            //if (_isMultipPlayer.onClick)
            //{
            //    _isSinglePlayer.enabled = false;
            //    _isMultipPlayer.enabled = true;
            //    GameManager.Instance.MultiPlayerLobbyClicked();
            //}
            //_activeToggle = CivilizationGroup.ActiveToggles().ToArray().FirstOrDefault();
            //ActiveToggle();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
