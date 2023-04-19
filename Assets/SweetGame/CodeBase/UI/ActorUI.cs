using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Game.Player;
using UnityEngine;

namespace SweetGame.CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;
        private IHealth _playerHealth;

        private void OnDestroy() => 
            _playerHealth.ChangeHealth -= UpdateUI;

        public void UpdateUI() => 
            HpBar.SetValue(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);

        public void Construct(IHealth playerHealth)
        {
            _playerHealth = playerHealth;
            playerHealth.ChangeHealth += UpdateUI;
        }
    }
}