using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        public EnemyDeath EnemyDeath;
        private IGameFactory _factory;
        private IRandomService _random;
        private int _min;
        private int _max;

        public void Construct(IGameFactory factory, IRandomService random)
        {
            _factory = factory;
            _random = random;
        }

        private void Start()
        {
            EnemyDeath = GetComponent<EnemyDeath>();
            EnemyDeath.OnDeath += SpawnLoot;
        }

        private void SpawnLoot()
        {
            LootPiece loot = _factory.CrateLoot();
            loot.transform.position =  transform.position + Vector3.up * 0.5f;
           
            var lootItem = GenerateLoot();
            loot.Initialize(lootItem);
        }

        private Loot GenerateLoot()
        {
            return new Loot()
            {
                Value = _random.GetRandom(_min, _max)
            };
        }

        public void SetLoot(int min, int max)
        {
            _min = min;
            _max = max;
        }
    }
}