using SweetGame.Tools.Resource;
using SweetGame.Abstractions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetGame.UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/UI/MainMenu");
        private readonly ProfileGame profileGame;
        private readonly MainMenuView view;

        public MainMenuController(ProfileGame profileGame, Transform placeForUI)
        {
            this.profileGame = profileGame;
            view = LoadView(placeForUI);
            view.Init(StartGame, profileGame);
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
    }
}
