using UnityEngine;

namespace SweetGame
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
    }
}