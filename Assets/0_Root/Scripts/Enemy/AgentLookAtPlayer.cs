using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SweetGame.Enemy
{
    public class AgentLookAtPlayer : MonoBehaviour
    {
        public EnemyAnimator EnemyAnimator;

        public void Start()
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            EnemyAnimator.PlayLookUp();
        }

        private void OnDisable()
        {
            EnemyAnimator.PlayLookUp();
        }
    }
}