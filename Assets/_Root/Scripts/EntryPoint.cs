using SweetGame.Abstractions;
using SweetGame.Abstractions.Base;
using SweetGame.Animations;
using SweetGame.Enemy;
using SweetGame.Spawner;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Background;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player playerController;
        [SerializeField] private BoardField boardField;
        [SerializeField] private float speed;
        [SerializeField] private AssetsContext assetsContext;
        [SerializeField] private SpriteAnimationsConfig spriteAnimationsConfig;

        private ListExecutiveObject listExecutiveObjects;

        private EnemyFactory enemyFactory;
        private ProfileGame profileGame;
        private MainController mainController;
        private TapeBackground background;

        private void Start()
        {
            profileGame = new ProfileGame();
            listExecutiveObjects = new ListExecutiveObject();
            playerController.OnDead += GameOver;

            enemyFactory = new EnemyFactory(profileGame);
            assetsContext.Inject(enemyFactory);

            // Inject spawnPoint to fields in SpawnController
            SpawnController spawnController = new SpawnController(enemyFactory, listExecutiveObjects);
            assetsContext.Inject(spawnController);
            spawnController.CreateObject();

            boardField.Points = spawnController.Points;

            BackgroundController backgroundController = assetsContext.Inject(new BackgroundController());
            listExecutiveObjects.AddExecuteObject(backgroundController);


            //
            mainController = new MainController(profileGame);


            SpriteAnimator spriteAnimator = new SpriteAnimator(spriteAnimationsConfig);


        }

        private void GameOver()
        {
            Debug.Log("Game Over");
        }

        private void Update()
        {
            SpriteAnimator.instance.Update();
            for (int i = 0; i < listExecutiveObjects.Length; i++)
            {
                var execute = listExecutiveObjects[i];
                if (execute == null)
                    continue;

                if(execute is IExecute _execute)
                    _execute.Execute();
            }

        }
    }
}
