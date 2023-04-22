using SweetGame.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.AssetMenegment
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string prefabPath, Vector3 position);
    }
}