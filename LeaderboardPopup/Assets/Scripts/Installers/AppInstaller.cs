using Modules.LaunchButton.AssetPackage.Scripts;
using Services;
using Services.AssetProviders;
using SimplePopupManager;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private LaunchButtonView launchButton;
        
        public override void InstallBindings()
        {
            BindServices();
            BindMonoBehaviours();
        }

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IAssetProviderService>().To<AssetProviderService>().AsSingle();
            Container.Bind<IPopupManagerService>().To<PopupManagerService>().AsSingle().NonLazy();
            Container.Bind<ILeaderboardDataService>().To<LeaderboardDataService>().AsSingle().NonLazy();
            Container.Bind<IInjectedPrefabsService>().To<InjectedPrefabsService>().AsSingle().NonLazy();
        }
        
        private void BindMonoBehaviours()
        {
            InitGameObjectWithComponent<LaunchButtonView>(launchButton);
        }
        
        private void InitGameObjectWithComponent<T>(Object prefab) where T : Component
        {
            var canvas = FindObjectOfType<Canvas>().transform;
            Container.InstantiatePrefabForComponent<T>(prefab, canvas);
        }
    }
}