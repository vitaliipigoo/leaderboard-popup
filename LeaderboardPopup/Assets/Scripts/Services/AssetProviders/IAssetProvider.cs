using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Services.AssetProviders
{
    public interface IAssetProvider
    {
        UniTask<T> LoadAssetAsync<T>(string key) where T : class;
    }
}