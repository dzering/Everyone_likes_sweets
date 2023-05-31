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

        public void Initialize() => 
            Addressables.InitializeAsync();

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCash.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithCashOnComplete(
                Addressables.LoadAssetAsync<T>(assetReference),
                assetReference.AssetGUID);
        }

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_completedCash.TryGetValue(address, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;
            
            return await RunWithCashOnComplete(
                Addressables.LoadAssetAsync<T>(address),
                address);
        }

        private async Task<T> RunWithCashOnComplete<T>(AsyncOperationHandle<T> handle, string cashKey) where T : class
        {
            handle.Completed += (completeHandle) =>
                _completedCash[cashKey] = completeHandle;

            AddHandle(cashKey, handle);

            return await handle.Task;
        }

        private void AddHandle<T>(string assetGUID, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(assetGUID, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[assetGUID] = resourceHandles;
            }

            _handles[assetGUID].Add(handle);
        }

        public void CleanUp()
        {
            foreach (var resourceHandles in _handles.Values)
            foreach (AsyncOperationHandle handle in resourceHandles)
                Addressables.Release(handle);
            _completedCash.Clear();
            _handles.Clear();
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