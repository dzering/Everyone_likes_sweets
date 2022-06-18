using System;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bird bird;
        [SerializeField] private float speed;
        private ProfileGame profileGame;
        private MainController mainController;

        private void Start()
        {
            profileGame = new ProfileGame(StateGame.Menu);
            mainController = new MainController(profileGame);
            bird.Init(speed);
        }
    }
}
