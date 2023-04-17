using System;
using System.Reflection;
using Object = UnityEngine.Object;

namespace SweetGame.CodeBase.Utils.AssetsInjector
{
    internal static class AssetInjector
    {
        private static readonly Type injectAssetAttributeType = typeof(InjectAssetAttribute);
        public static T Inject<T>(this AssetsContext context, T target)
        {
            Type targetType = target.GetType();
            FieldInfo[] allFields = targetType.GetFields
                (BindingFlags.Public |
                BindingFlags.NonPublic|
                BindingFlags.Instance);

            for (int i = 0; i < allFields.Length; i++)
            {
                FieldInfo fieldInfo = allFields[i];
                InjectAssetAttribute injectAssetAttribute = fieldInfo.GetCustomAttribute(injectAssetAttributeType) as InjectAssetAttribute;
                if (injectAssetAttribute == null)
                    continue;

                Object objectToInject = context.GetObjectOfTypr(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                fieldInfo.SetValue(target, objectToInject);
            }

            return target;
        }

    }
}
