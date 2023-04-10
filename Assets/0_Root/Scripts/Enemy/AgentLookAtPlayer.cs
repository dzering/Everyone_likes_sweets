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
        
    }
}