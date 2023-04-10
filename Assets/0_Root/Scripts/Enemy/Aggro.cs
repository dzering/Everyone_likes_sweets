using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetGame.Enemy
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AgentLookAtPlayer AgentLookAtPlayer;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchOn(false);
        }

        private void TriggerExit(Collider2D obj)
        {
            SwitchOn(false);
        }

        private void TriggerEnter(Collider2D obj)
        {
            SwitchOn(true);
        }

        private void SwitchOn(bool isEnabled)
        {
            AgentLookAtPlayer.enabled = isEnabled;
        }
    }
}