using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SweetGame.CodeBase.Game.Spawner
{
    public class Spawner : MonoBehaviour
    {
        public float Delay = 3f;
        private bool _canSpawn;
        private ISpawnPoint[] _spawnPoints;

        public void Construct(List<ISpawnPoint> spawnPoints)
        {
            _canSpawn = true;
            InitializeSpawners(spawnPoints);
        }

        private void Update() => 
            CheckSpawn();

        private void CheckSpawn()
        {
            if(!_canSpawn)
                return;
            _canSpawn = false;
            Spawn();
            StartCoroutine(Check());
        }

        private void InitializeSpawners(List<ISpawnPoint> spawnPoints)
        {
            _spawnPoints = new ISpawnPoint[spawnPoints.Count];
            int i = 0;
            foreach (ISpawnPoint spawnPoint in spawnPoints) 
                _spawnPoints[i++] = spawnPoint;
        }

        private IEnumerator Check()
        {
            yield return new WaitForSeconds(Delay + Random.Range(0, 3));
            _canSpawn = true;
        }

        private void Spawn() => 
            _spawnPoints[Random.Range(0,_spawnPoints.Length)]?.Spawn();
    }
}