using SweetGame.CodeBase.Animators;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class AgentLookAtPlayer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;

        public void Start() => 
            LookAtPlayer();

        private void LookAtPlayer() => 
            _enemyAnimator.PlayLookUp();

        private void OnEnable() =>
            LookAtPlayer();

        private void OnDisable() =>
            LookAtPlayer();
    }
}