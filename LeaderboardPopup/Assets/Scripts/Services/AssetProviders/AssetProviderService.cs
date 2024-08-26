using Cysharp.Threading.Tasks;

namespace Services.AssetProviders
{
    public class AssetProviderService : IAssetProviderService
    {
        private readonly IAssetProvider _assetProvider;

        public AssetProviderService(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public async UniTask<T> LoadAssetAsync<T>(string key) where T : class
        {
            var result = await _assetProvider.LoadAssetAsync<T>(key);
            return result;
        }
    }
}