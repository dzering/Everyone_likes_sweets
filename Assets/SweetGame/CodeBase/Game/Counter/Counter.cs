using System;
using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Counter
{
    public class Counter : MonoBehaviour
    {
        private WorldData _worldData;

        public void Constract(IProgressService progressService) => 
            _worldData = progressService.PlayerProgress.WordData;

        private void Update()
        {
            if (transform.position.x < 0)
            {
                _worldData.LootData.Add(1);
                enabled = false;
            }
        }
    }
}