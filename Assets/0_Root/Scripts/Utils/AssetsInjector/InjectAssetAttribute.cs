using System;

namespace SweetGame.Utils.AssetsInjector
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class InjectAssetAttribute : Attribute
    {
        public readonly string AssetName;
        public InjectAssetAttribute(string assetName = null)
        {
            AssetName = assetName;
        }
    }
}
