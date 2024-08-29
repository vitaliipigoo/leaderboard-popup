//© 2023 Sophun Games LTD. All rights reserved.
//This code and associated documentation are proprietary to Sophun Games LTD.
//Any use, reproduction, distribution, or release of this code or documentation without the express permission
//of Sophun Games LTD is strictly prohibited and could be subject to legal action.

using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services;
using Services.AssetProviders;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SimplePopupManager
{
    /// <summary>
    ///     Manages popups, providing functionality for opening, closing, and loading popups.
    /// </summary>
    public class PopupManagerService : IPopupManagerService
    {
        private readonly IInjectedPrefabsService _injectedPrefabsService;
        private readonly IAssetProviderService _assetProviderService;
        private readonly Dictionary<string, GameObject> _popups = new();

        private Transform _popupsCanvas;

        public PopupManagerService(
            IInjectedPrefabsService injectedPrefabsService, 
            IAssetProviderService assetProviderService)
        {
            _injectedPrefabsService = injectedPrefabsService;
            _assetProviderService = assetProviderService;
        }

        /// <summary>
        ///     Opens a popup by its name and initializes it with the given parameters.
        ///     If the popup is already loaded, it will log an error and return.
        /// </summary>
        /// <param name="name">The name of the popup to open.</param>
        /// <param name="param">The parameters to initialize the popup with.</param>
        public async void OpenPopup<T>(string name, object param) where T : IPopup
        {
            if (_popups.ContainsKey(name))
            {
                Debug.LogError($"Popup with name {name} is already shown");
                return;
            }

            await LoadPopup<T>(name, param);
        }

        /// <summary>
        ///     Closes a popup by its name.
        ///     If the popup is loaded, it will release its instance and remove it from the dictionary.
        /// </summary>
        /// <param name="name">The name of the popup to close.</param>
        public void ClosePopup(string name)
        {
            if (!_popups.ContainsKey(name))
                return;

            var popup = _popups[name];
            popup.GetComponent<IPopup>().OnCloseButtonClick -= ClosePopup;
            Addressables.ReleaseInstance(popup);
            Object.Destroy(popup);
            _popups.Remove(name);
        }

        public void SetPopupsRootCanvas(Transform instanceTransform) => _popupsCanvas = instanceTransform;

        /// <summary>
        ///     Loads and instantiates a popup from Unity's addressable system using the provided name.
        ///     Then initializes the popup with the provided parameters.
        ///     If the popup doesn't have any IPopupInitialization components, it will log an error and release its instance.
        /// </summary>
        /// <param name="name">The name of the popup to load.</param>
        /// <param name="param">The parameters to initialize the popup with.</param>
        private async UniTask LoadPopup<T>(string name, object param) where T : IPopup
        {
            var popupObject = await _assetProviderService.LoadAssetAsync<GameObject>(name);
            var popupPrefab = _injectedPrefabsService.InstantiatePrefab(popupObject, _popupsCanvas);
            _injectedPrefabsService.Inject(popupPrefab.GetComponent<T>());

            popupPrefab.SetActive(true);
            _popups.Add(name, popupPrefab);
            var popupComponent = popupPrefab.GetComponent<IPopup>();

            if (popupComponent != null)
            {
                await popupComponent.Init(param);
                popupComponent.OnCloseButtonClick += ClosePopup;
            }
        }
    }
}