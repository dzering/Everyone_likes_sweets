using SweetGame.CodeBase.Game.Player;
using UnityEngine;

namespace SweetGame.CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;
        private PlayerHealth _playerHealth;

        private void OnDestroy() => 
            _playerHealth.ChangeHealth -= UpdateUI;

        public void UpdateUI() => 
            HpBar.SetValue(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

        public void Construct(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
            playerHealth.ChangeHealth += UpdateUI;
        }
    }
}