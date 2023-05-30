using System.Threading.Tasks;
using SweetGame.CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SweetGame.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string prefabPath, Vector3 position);
        GameObject Instantiate(string prefPath, Transform transform, bool b);
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        void CleanUp();
    }
}