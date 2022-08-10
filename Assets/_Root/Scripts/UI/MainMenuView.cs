using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using SweetGame.Player;

namespace SweetGame.UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button prevButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Image currentPlayer;

        private ProfileGame profileGame;

        public void Init(UnityAction startGame, ProfileGame profileGame)
        {
            startButton.onClick.AddListener(startGame);
            this.profileGame = profileGame;
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }

        private void ChoosePlayer()
        {

        }
    }
}
