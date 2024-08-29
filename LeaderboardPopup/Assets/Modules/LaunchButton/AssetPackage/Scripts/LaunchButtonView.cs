using System;
using Constants;
using Services;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.LaunchButton.AssetPackage.Scripts
{
    public class LaunchButtonView : MonoBehaviour
    {
        private Button _launchButton;

        private IPopupManagerService _popupManagerService;
        private ILeaderboardDataService _leaderboardDataService;
        
        [Inject]
        public void Construct(
            IPopupManagerService popupManagerService,
            ILeaderboardDataService leaderboardDataService)
        {
            _popupManagerService = popupManagerService;
            _leaderboardDataService = leaderboardDataService;
        }

        private void Awake()
        {
            _launchButton = gameObject.GetComponent<Button>();
            AddButtonsListeners();
        }

        private void OnDestroy()
        {
            _launchButton.onClick.RemoveAllListeners();
        }
        
        private void AddButtonsListeners()
        {
            _launchButton.onClick.AddListener(OnLaunchClick);
        }

        private void OnLaunchClick()
        {
            _popupManagerService.OpenPopup(PopupConstants.LeaderboardPopup, _leaderboardDataService.LeaderboardData);
        }
    }
}