using SweetGame.Abstractions;
using SweetGame.Game.Sweets;
using SweetGame.Game.Spawn;
using SweetGame.Background;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Animations;
using SweetGame.Enemy;
using UnityEngine;
using JoostenProductions;

namespace SweetGame.Game
{
    internal class GameController : BaseController
    {
        private readonly GameContext _context;
        private readonly Transform _placeForUI;
       
        private CakeController player;
        private readonly Spawner _spawner;

        private BoardField boardField;

        private EnemyFactory enemyFactory;

        private ListExecutiveObject listExecutiveObjects;

        protected override void OnDispose()
        {
            listExecutiveObjects.ClearList();
            player.OnDead -= GameOver;
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }

        public GameController(GameContext profileGame, AssetsContext assetsContext, Transform placeForUI)
        {
            _context = profileGame;
            _placeForUI = placeForUI;
            listExecutiveObjects = new ListExecutiveObject();
           
            player = new CakeController();
            player.OnDead += GameOver;


            BackgroundController backgroundController = assetsContext.Inject(new BackgroundController());
            backgroundController.Init();
            listExecutiveObjects.AddExecuteObject(backgroundController);

            SpriteAnimator spriteAnimator = assetsContext.Inject(new SpriteAnimator());
            _spawner = new Spawner(_context);
            _spawner.CreateEnemy(new BirdCreator());
          //  boardField = new BoardField(spawnController.Points);

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
