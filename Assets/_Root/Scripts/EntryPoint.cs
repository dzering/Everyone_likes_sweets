using SweetGame.Enemy;
using SweetGame.Abstractions;
using SweetGame.Spawner;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private AssetsContext assetsContext;
        
        private InteractiveObject[] interactiveObjects;

        private EnemyFactory enemyFactory;
        private ProfileGame profileGame;
        private MainController mainController;

        private IMove child;
        private IMove bird;

        private void Start()
        {
            profileGame = new ProfileGame(StateGame.Menu);
            enemyFactory = new EnemyFactory(profileGame);
            assetsContext.Inject(enemyFactory);

            child = enemyFactory.GetEnemy(EnemyType.Child);
            bird = enemyFactory.GetEnemy(EnemyType.Bird);
            mainController = new MainController(profileGame);


        }

        private void Update()
        {
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                var interactiveObject = interactiveObjects[i];
                if (interactiveObject == null)
                    continue;

                if (interactiveObject is IMove move)
                    move.Move();
            }


            //child.Move();
            //bird.Move();
        }
    }
}
