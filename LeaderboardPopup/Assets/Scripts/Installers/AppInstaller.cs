using Modules.SimplePopupManager.Services;
using Services.AssetProviders;
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
            Container.Bind<IPopupInitializationService>().To<PopupInitializationService>().AsSingle().NonLazy();
        }
    }
}