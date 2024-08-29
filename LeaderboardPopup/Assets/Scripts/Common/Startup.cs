using Cysharp.Threading.Tasks;
using Services;
using Services.AssetProviders;
using SimplePopupManager;
using UnityEngine;
using Zenject;

namespace Common
{
    public class Startup : MonoBehaviour
    {
        private const string Canvas = "Canvas";
        private const string LaunchButton = "LaunchButton";
        
        private IInjectedPrefabsService _injectedPrefabsService;
        private IAssetProviderService _assetProviderService;
        private IPopupManagerService _popupManagerService;

        private Transform _popupCanvas;

        [Inject]
        private void Construct(
            IInjectedPrefabsService injectedPrefabsService,
            IAssetProviderService assetProviderService,
            IPopupManagerService popupManagerService)
        {
            _injectedPrefabsService = injectedPrefabsService;
            _assetProviderService = assetProviderService;
            _popupManagerService = popupManagerService;
        }

        private void Awake()
        {
            CreateView().Forget();
        }

        private async UniTask CreateView()
        {
            await InstantiatePopupsCanvas();
            await InstantiateLaunchButton();
        }

        private async UniTask InstantiatePopupsCanvas()
        {
            var popupObject = await _assetProviderService.LoadAssetAsync<GameObject>(Canvas);
            var popupCanvas = Instantiate(popupObject);
            
            _popupManagerService.SetPopupsRootCanvas(popupCanvas.transform);
            _popupCanvas = popupCanvas.transform;
            DontDestroyOnLoad(popupCanvas);
        }

        private async UniTask InstantiateLaunchButton()
        {
            var launchBtnObject = await _assetProviderService.LoadAssetAsync<GameObject>(LaunchButton);
            _injectedPrefabsService.InstantiatePrefab(launchBtnObject, _popupCanvas);
        }
    }
}