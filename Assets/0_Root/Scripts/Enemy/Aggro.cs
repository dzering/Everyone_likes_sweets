using System.Collections;
using UnityEngine;

namespace SweetGame.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        
        public AgentLookAtPlayer AgentLookAtPlayer;
        public Follow EnemyMove;
        
        private Coroutine _switchCoroutine;

        public float CoolDownTime;
        private bool _hasTarget;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchLookAt(false);
        }

        private void TriggerEnter(Collider2D obj)
        {
            if (!_hasTarget)
            {
                _hasTarget = true;
                StopSwitchCoroutine();
            
                SwitchMove(false);
                SwitchLookAt(true);
            }
        }

        private void TriggerExit(Collider2D obj)
        {
            if (_hasTarget)
            {
                _hasTarget = false;
                _switchCoroutine = StartCoroutine(SwitchStateAfterCoolDown());
            }
        }

        private void StopSwitchCoroutine()
        {
            if (_switchCoroutine != null)
            {
                StopCoroutine(_switchCoroutine);
                _switchCoroutine = null;
            }
        }

        private IEnumerator SwitchStateAfterCoolDown()
        {
            yield return new WaitForSeconds(CoolDownTime);
            SwitchLookAt(false);
            SwitchMove(true);
        }

        private void SwitchMove(bool isEnabled) => 
            EnemyMove.enabled = isEnabled;

        private void SwitchLookAt(bool isEnabled) => 
            AgentLookAtPlayer.enabled = isEnabled;
    }
}