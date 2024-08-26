using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Services.AssetProviders
{
    public interface IAssetProviderService
    {
        UniTask<T> LoadAssetAsync<T>(string key) where T : class;
    }
}