using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.Utils.AssetsInjector
{
    [CreateAssetMenu(fileName =nameof(AssetsContext), menuName = "SweetGame/" + nameof(AssetsContext))]
    public class AssetsContext : ScriptableObject
    {
        [SerializeField] private Object[] assets;

        public Object GetObjectOfTypr(Type assetType, string assetName = null)
        {
            for (int i = 0; i < assets.Length; i++)
            {
                Object asset = assets[i];
                if (asset.GetType().IsAssignableFrom(assetType))
                {
                    if(assetName == null || asset.name == assetName)
                    {
                        return asset;
                    }
                }
            }
            return null;

        }
    }
}
