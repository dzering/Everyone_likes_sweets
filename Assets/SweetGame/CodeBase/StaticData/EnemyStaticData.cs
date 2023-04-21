using SweetGame.CodeBase.Game.Spawner;
using UnityEngine;

namespace SweetGame.CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Enemy", fileName = nameof(EnemyStaticData))]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;

        public int LootMin;
        public int LootMax;
        
        [Range(1, 30)] public float Damage;
        [Range(0.5f, 1)] public float AttackRadius;
        [Range(1, 100)] public float Health;
        [Range(0.2f, 2)] public float CoolDownTimeAttack;


        public GameObject Prefab;
    }
    
}