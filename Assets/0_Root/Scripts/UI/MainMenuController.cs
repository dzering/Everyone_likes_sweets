using SweetGame.Tools.Resource;
using SweetGame.Abstractions;
using UnityEngine;
using Object = UnityEngine.Object;
using SweetGame.Utils.Extension;
using SweetGame.Game.Sweets;
using System;

namespace SweetGame.UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/UI/MainMenu");
        private readonly ProfileGame profileGame;
        private readonly MainMenuView view;
        private SweetController sweetController;

        public MainMenuController(ProfileGame profileGame, Transform placeForUI)
        {
            this.profileGame = profileGame;
            view = LoadView(placeForUI);
            view.Init(StartGame, ChooseNext, ChoosePrevious);
            ChooseNext();
        }


        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject pref = ResourceLoader.LoadGameObject(path);
            GameObject go = Object.Instantiate(pref);
            go.transform.SetParent(placeForUI, false);

            AddGameObject(go);


            return go.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            profileGame.State.Value = StateGame.Game;
        }
        private void ChoosePrevious()
        {
            profileGame.currentPlayer = profileGame.currentPlayer.Previous();
            view.Image.sprite = ChoosePlayer();

            Debug.Log(profileGame.currentPlayer.ToString());
        }

        private void ChooseNext()
        {
            profileGame.currentPlayer = profileGame.currentPlayer.Next();
            view.Image.sprite = ChoosePlayer();

            Debug.Log(profileGame.currentPlayer.ToString());
        }

        private Sprite ChoosePlayer()
        {
            view.Image.sprite = null;
            SweetController sweetController =
                profileGame.currentPlayer switch
                {
                    SweetType.Cake => new CakeController(),
                    SweetType.Candy => new CandyController(),
                    _ => throw new ArgumentException(nameof(SweetType))
                };

            Debug.Log(sweetController.ToString());

            Sprite sprite = sweetController.Sweet?.GetComponent<SpriteRenderer>().sprite;
            
            sweetController?.Dispose();

            return sprite;

        }
    }
}
