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

        [HideInInspector] public SubscriptionProperty<StateGame> State;
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


        private void Start()
        {
            _enemies = new List<EnemyBase>();
            ExecutiveObjects = new ListExecutiveObject();
            State = new SubscriptionProperty<StateGame>();
            State.Value = StateGame.Menu;
            currentPlayer = 0;
        }
    }
}
