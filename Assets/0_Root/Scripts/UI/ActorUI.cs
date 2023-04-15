using System;
using SweetGame.Game.Sweets;
using UnityEngine;

namespace SweetGame.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;
        private PlayerHealth _playerHealth;

        private void OnDestroy() => 
            _playerHealth.OnChangeHealth -= UpdateUI;

        public void UpdateUI() => 
            HpBar.SetValue(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

        public void Construct(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
            playerHealth.OnChangeHealth += UpdateUI;
        }
    }
}