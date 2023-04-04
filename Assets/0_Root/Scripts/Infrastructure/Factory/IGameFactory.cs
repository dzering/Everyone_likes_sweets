using UnityEngine;

namespace SweetGame
{
    public interface IGameFactory : IService
    {
        GameObject CreateMainGame();
    }
}