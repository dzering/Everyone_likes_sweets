using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace SweetGame.CodeBase.Infrastructure.AssetManagement
{
    public sealed class AssetsProvider : IAssets
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCash = 
            new Dictionary<string, AsyncOperationHandle>();

        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles =
            new Dictionary<string, List<AsyncOperationHandle>>();

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCash.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle complitedHandle))
                return complitedHandle.Result as T;
            
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetReference);
            handle.Completed += (h )=> 
                _completedCash[assetReference.AssetGUID] = h;
            
            AddHandle(assetReference, handle);

            return await handle.Task;
        }

        public void CleanUp()
        {
            foreach (var resourceHandles in _handles.Values)
            foreach (AsyncOperationHandle handle in resourceHandles)
                Addressables.Release(handle);
        }

        private void AddHandle<T>(AssetReference assetReference, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(assetReference.AssetGUID, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[assetReference.AssetGUID] = resourceHandles;
            }

            _handles[assetReference.AssetGUID].Add(handle);
        }


        public GameObject Instantiate(string path)
        {
            var pref = Resources.Load<GameObject>(path);
            return Object.Instantiate(pref);
        }

        public GameObject Instantiate(string prefabPath, Vector3 position)
        {
            GameObject pref = Resources.Load<GameObject>(prefabPath);
            return GameObject.Instantiate(pref, position, Quaternion.identity);
        }

        public GameObject Instantiate(string prefPath, Transform transform, bool b)
        {
            GameObject pref = Resources.Load<GameObject>(prefPath);
            return GameObject.Instantiate(pref, transform);
        }
    }
}