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
    public class GameController : BaseController
    {
        private readonly GameContext _context;
        private readonly Transform _placeForUI;
       
        private CakeController _player;
        private readonly Spawner _spawner;

        private BoardField boardField;

        private EnemyFactory enemyFactory;

        private ListExecutiveObject _listExecutiveObjects;

        protected override void OnDispose()
        {
            _listExecutiveObjects.ClearList();
            _player.OnDead -= GameOver;
            JoostenProductions.UpdateManager.UnsubscribeFromUpdate(Update);
        }

        public GameController(GameContext profileGame, AssetsContext assetsContext, Transform placeForUI, CakeController player)
        {
            _player = player;
            
            _context = profileGame;
            _placeForUI = placeForUI;
            _listExecutiveObjects = _context.ExecutiveObjects;

            player.OnDead += GameOver;


            BackgroundController backgroundController = assetsContext.Inject(new BackgroundController());
            backgroundController.Init();
            _listExecutiveObjects.AddExecuteObject(backgroundController);

            SpriteAnimator spriteAnimator = assetsContext.Inject(new SpriteAnimator());

            _spawner = new Spawner(_context);
            _spawner.CreateEnemy(new BirdCreator());
            _spawner.CreateEnemy(new ChildCreator());
            
            new Border();

            JoostenProductions.UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            //SpriteAnimator.instance.Update();
            for (int i = 0; i < _listExecutiveObjects.Length; i++)
            {
                var execute = _listExecutiveObjects[i];
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
