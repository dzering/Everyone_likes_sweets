using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using SweetGame.Game.Sweets;

namespace SweetGame.UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button prevButton;
        [SerializeField] private Button nextButton;
        [SerializeField] public Image Image;

        public void Init(UnityAction startGame, UnityAction chooseNext, UnityAction choosePrevious)
        {
            startButton.onClick.AddListener(startGame);
            nextButton.onClick.AddListener(chooseNext);
            prevButton.onClick.AddListener(choosePrevious);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
            nextButton.onClick.RemoveAllListeners();
            prevButton.onClick.RemoveAllListeners();
        }

        
    }
}
