using System;
using System.Collections.Generic;
using Constants;
using Cysharp.Threading.Tasks;
using Models.Leaderboard;
using Services;
using Services.AssetProviders;
using SimplePopupManager;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.LeaderboardPopup.AssetPackage.Scripts
{
    public class LeaderboardPopupView : MonoBehaviour, IPopup
    {
        private const string Item = "Item";
        
        public event Action<string> OnCloseButtonClick;
        public string PopupName => PopupConstants.LeaderboardPopup;

        [SerializeField] private Transform contentTransform;
        [SerializeField] private Button closeButton;
        [SerializeField] private LeaderboardItemView itemReference;
        [SerializeField] private List<LeaderboardItemView> items;
        
        private IAssetProviderService _assetProviderService;

        private LeaderboardDataModel _leaderboardDataModel;
        
        [Inject]
        public void Construct(IAssetProviderService assetProviderService)
        {
            _assetProviderService = assetProviderService;
        }

        public async UniTask Init(object param)
        {
            _leaderboardDataModel = param as LeaderboardDataModel;
            await InstantiateLeaderboardItems();
        }

        private async UniTask InstantiateLeaderboardItems()
        {
            var itemsCount = _leaderboardDataModel.Leaderboard.Count - items.Count;
            
            for (var i = 0; i < itemsCount; i++)
            {
                var item = Instantiate(itemReference, contentTransform);
                items.Add(item);
            }
        }

        public void CloseButtonClick() => OnCloseButtonClick?.Invoke(PopupName);
        
        private void Awake()
        {
            AddButtonsListeners();
        }
        
        private void AddButtonsListeners()
        {
            closeButton.onClick.AddListener(CloseButtonClick);
        }
        
        public void OnDestroy()
        {
            closeButton.onClick.RemoveAllListeners();
        }
    }
}