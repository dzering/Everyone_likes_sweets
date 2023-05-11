using SweetGame.CodeBase.Animators;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.CodeBase.Game.Enemy
{
    public class AgentLookAtPlayer : MonoBehaviour
    {
        [FormerlySerializedAs("_enemyAnimator")] public EnemyAnimatorBase _enemyAnimatorBase;

        public void Start() => 
            LookAtPlayer();

        private void LookAtPlayer() => 
            _enemyAnimatorBase.PlayLookUp();

        private void OnEnable() =>
            LookAtPlayer();

        private void OnDisable() =>
            LookAtPlayer();
    }
}