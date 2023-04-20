using System;
using SweetGame.CodeBase.Abstractions;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.StaticData;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        public EnemyDeath EnemyDeath;
        private IGameFactory _factory;

        public void Construct(IGameFactory factory) => 
            _factory = factory;

        private void Start()
        {
            EnemyDeath = GetComponent<EnemyDeath>();
            EnemyDeath.OnDeath += SpawnLoot;
        }

        private void SpawnLoot()
        {
            GameObject loot = _factory.CrateLoot();
            loot.transform.position =  transform.position + Vector3.up * 0.5f;
        }
    }
}