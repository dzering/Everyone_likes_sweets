using SweetGame.Tools.Reaction;
using SweetGame.Game.Sweets;
using SweetGame.Data.Spawner;
using SweetGame.Abstractions;
using UnityEngine;
using System.Collections.Generic;

namespace SweetGame
{
    public sealed class GameContext : MonoBehaviour
    {
        [HideInInspector] public ListExecutiveObject ExecutiveObjects;

        [Header("General settings")]
        [SerializeField] public float GameSpeed = 2;

        [HideInInspector] public SubscriptionProperty<StateGame> State = new SubscriptionProperty<StateGame>();
        [HideInInspector] public SweetType currentPlayer;

        [Header("Enemy")]
        private List<EnemyBase> _enemies;
        [HideInInspector] public List<EnemyBase> Enemies
        {
            get { return _enemies; }
            set { _enemies = value; }
        }

        [Header("Spawn position")]
        [SerializeField] public SpawnPointsConfig SpawnPointsConfig;


        private void Awake()
        {
            _enemies = new List<EnemyBase>();
            ExecutiveObjects = new ListExecutiveObject();
            State.Value = StateGame.Menu;
            currentPlayer = 0;
        }
    }
}
