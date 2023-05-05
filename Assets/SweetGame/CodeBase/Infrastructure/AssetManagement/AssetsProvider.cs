using UnityEngine;


namespace SweetGame.CodeBase.Infrastructure.AssetManagement
{
    public sealed class AssetsProvider : IAssets
    {
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
    }
}