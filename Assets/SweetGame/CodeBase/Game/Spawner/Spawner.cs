using System.Collections;
using System.Collections.Generic;
using SweetGame.CodeBase.Infrastructure;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Spawner
{
    public class Spawner
    {
        private readonly ICoroutineRunner _coroutine;
        private readonly int _requiredEnemies = 4;
        private int _currentEnemies;

        private ISpawnPoint[] _spawnPoints;
        private bool _canSpawn;

        public Spawner(List<ISpawnPoint> spawnPoints, ICoroutineRunner coroutine)
        {
            _coroutine = coroutine;
            _canSpawn = true;
            InitializeSpawners(spawnPoints);
            SpawnEnemies(_requiredEnemies);
        }

        public void OnUpdateAmount()
        {
            _currentEnemies = 0;
            foreach (var spawnPoint in _spawnPoints) 
                _currentEnemies += spawnPoint.EnemyDeaths.Count;
            
            SpawnEnemies(_requiredEnemies);
        }

        private void InitializeSpawners(List<ISpawnPoint> spawnPoints)
        {
            _spawnPoints = new ISpawnPoint[spawnPoints.Count];
            int i = 0;
            foreach (ISpawnPoint spawnPoint in spawnPoints)
            {
                _spawnPoints[i++] = spawnPoint;
                spawnPoint.UpdateCount += OnUpdateAmount;
            }
        }

        public void SpawnEnemies(int amount)
        {
            if(_requiredEnemies <= _currentEnemies || !_canSpawn)
                return;
            
            _canSpawn = false;
            _coroutine.StartCoroutine(Spawn(amount));
        }

        private IEnumerator Spawn(int amount)
        {
            Debug.Log("StartCoroutine");
            //Out of range exception (Remake formula)
            int j = 0;
            int length = _spawnPoints.Length;
            for (int i = 0; i <= amount; i++)
            {
                j = (i + length) % length;
                _spawnPoints[j].Spawn();
                yield return new WaitForSeconds(3f);
            }

            _canSpawn = true;
        }
    }
}