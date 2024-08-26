using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Services.AssetProviders
{
    public class AssetProvider : IAssetProvider
    {
        public async UniTask<T> LoadAssetAsync<T>(string key) where T : class
        {
            var assetHandle = Addressables.LoadAssetAsync<T>(key);
            var result = await assetHandle.Task;
            
            return result;
        }
    }
}