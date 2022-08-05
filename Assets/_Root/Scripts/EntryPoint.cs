using SweetGame.Abstractions;
using SweetGame.Abstractions.Base;
using SweetGame.Enemy;
using SweetGame.Spawner;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Player playerController;
        [SerializeField] private BoardField boardField;
        [SerializeField] private float speed;
        [SerializeField] private AssetsContext assetsContext;

        private ListExecutiveObject listExecutiveObjects;

        private EnemyFactory enemyFactory;
        private ProfileGame profileGame;
        private MainController mainController;

        private void Start()
        {
            profileGame = new ProfileGame(StateGame.Menu);
            enemyFactory = new EnemyFactory(profileGame);
            assetsContext.Inject(enemyFactory);
            playerController.OnDead += GameOver;
           
            listExecutiveObjects = new ListExecutiveObject();

            // Inject spawnPoint to fields in SpawnController
            SpawnController spawnController = new SpawnController(enemyFactory, listExecutiveObjects);
            assetsContext.Inject(spawnController);
            spawnController.CreateObject();

            boardField.Points = spawnController.Points;


            //
            mainController = new MainController(profileGame);
        }

        private void GameOver()
        {
            Debug.Log("Game Over");
        }

        private void Update()
        {
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
