using SweetGame.Abstractions;
using SweetGame.Player;
using SweetGame.Game.Spawner;
using SweetGame.Background;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Animations;
using UnityEngine;
using JoostenProductions;

namespace SweetGame.Game
{
    internal class GameController : BaseController
    {
        private readonly ProfileGame profileGame;
        private readonly Transform placeForUI;
       
        private PlayerController player;

        private BoardField boardField;

        private EnemyFactory enemyFactory;

        private ListExecutiveObject listExecutiveObjects;

        protected override void OnDispose()
        {
            listExecutiveObjects.ClearList();
            player.OnDead -= GameOver;
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }

        public GameController(ProfileGame profileGame, AssetsContext assetsContext, Transform placeForUI)
        {
            this.profileGame = profileGame;
            this.placeForUI = placeForUI;
            listExecutiveObjects = new ListExecutiveObject();
           
            player = new PlayerController();
            player.OnDead += GameOver;

            enemyFactory = new EnemyFactory(profileGame);
            assetsContext.Inject(enemyFactory);

            BackgroundController backgroundController = assetsContext.Inject(new BackgroundController());
            backgroundController.Init();
            listExecutiveObjects.AddExecuteObject(backgroundController);

            SpriteAnimator spriteAnimator = assetsContext.Inject(new SpriteAnimator());

            SpawnController spawnController = new SpawnController(enemyFactory, listExecutiveObjects);
            assetsContext.Inject(spawnController);
            spawnController.CreateObject();

            boardField = new BoardField(spawnController.Points);

            JoostenProductions.UpdateManager.SubscribeToUpdate(Update);

        }

        private void Update()
        {
            SpriteAnimator.instance.Update();
            for (int i = 0; i < listExecutiveObjects.Length; i++)
            {
                var execute = listExecutiveObjects[i];
                if (execute == null)
                    continue;

                if (execute is IExecute _execute)
                    _execute.Execute();
            }
        }

        private void GameOver()
        {
            Debug.Log("Game Over");
        }
    }
}
