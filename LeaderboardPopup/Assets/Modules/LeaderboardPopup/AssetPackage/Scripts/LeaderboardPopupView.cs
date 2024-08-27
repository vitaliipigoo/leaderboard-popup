using System;
using Constants;
using Cysharp.Threading.Tasks;
using SimplePopupManager;
using UnityEngine;

namespace Modules.LeaderboardPopup.AssetPackage.Scripts
{
    public class LeaderboardPopupView : MonoBehaviour, IPopup
    {
        public event Action<string> OnCloseButtonClick;
        
        public string PopupName => PopupConstants.LeaderboardPopup;

        public UniTask Init(object param)
        {
            throw new NotImplementedException();
        }

        public void CloseButtonClick() => OnCloseButtonClick?.Invoke(PopupName);
        
        private void Awake()
        {
            AddButtonsListeners();
        }
        
        private void AddButtonsListeners()
        {
            //closeButton.onClick.AddListener(CloseButtonClick);
        }
        
        public void OnDestroy()
        {
            //closeButton.onClick.RemoveAllListeners();
        }
    }
}