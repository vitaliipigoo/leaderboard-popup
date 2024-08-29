using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using Cysharp.Threading.Tasks;
using Models.Leaderboard;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.LeaderboardPopup.AssetPackage.Scripts
{
    public class LeaderboardPopupView : MonoBehaviour, IPopup
    {
        public event Action<string> OnCloseButtonClick;
        public string PopupName => PopupConstants.LeaderboardPopup;

        [SerializeField] private Transform contentTransform;
        [SerializeField] private Button closeButton;
        [SerializeField] private LeaderboardItemView itemReference;
        [SerializeField] private List<LeaderboardItemView> items;
        
        private LeaderboardDataModel _leaderboardDataModel;

        public void OnDestroy()
        {
            closeButton.onClick.RemoveAllListeners();
        }

        public UniTask Init(object param)
        {
            _leaderboardDataModel = param as LeaderboardDataModel;
            InstantiateLeaderboardItems();
            InitLeaderboardItems();
            
            return UniTask.CompletedTask;
        }

        private void InstantiateLeaderboardItems()
        {
            var itemsCount = _leaderboardDataModel.Leaderboard.Count - items.Count;
            
            for (var i = 0; i < itemsCount; i++)
            {
                var item = Instantiate(itemReference, contentTransform);
                items.Add(item);
            }
        }

        private void InitLeaderboardItems()
        {
            var sortedData = _leaderboardDataModel.Leaderboard.OrderByDescending(x => x.Score).ToList();

            for (int i = 0; i < sortedData.Count; i++)
                items[i].Init(sortedData[i]);
        }

        private void Awake() => AddButtonsListeners();

        private void AddButtonsListeners() => closeButton.onClick.AddListener(CloseButtonClick);

        private void CloseButtonClick() => OnCloseButtonClick?.Invoke(PopupName);
    }
}