using Services;
using Services.AssetProviders;
using SimplePopupManager;
using Zenject;

namespace Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IAssetProviderService>().To<AssetProviderService>().AsSingle();
            Container.Bind<IPopupManagerService>().To<PopupManagerService>().AsSingle().NonLazy();
            Container.Bind<ILeaderboardDataService>().To<LeaderboardDataService>().AsSingle().NonLazy();
            Container.Bind<IInjectedPrefabsService>().To<InjectedPrefabsService>().AsSingle().NonLazy();
        }
    }
}