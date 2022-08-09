using UnityEngine;

namespace SweetGame.Tools.Resource
{
    internal static class ResourceLoader
    {
        public static GameObject LoadGameObject(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.Path);
        }
    }
}
