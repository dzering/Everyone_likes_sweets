using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.AssetMenegment
{
    public sealed class AssetsProvider : IAssets
    {
        public GameObject Instantiate(string path)
        {
            var pref = Resources.Load<GameObject>(path);
            return Object.Instantiate(pref);
        }
    }
}