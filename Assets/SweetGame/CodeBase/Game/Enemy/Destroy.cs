using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class Destroy : MonoBehaviour
    {
        public event Action DestroyEvent;

        private void OnDestroy()
        {
            DestroyEvent?.Invoke();
        }
    }
}