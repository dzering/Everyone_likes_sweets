using SweetGame.Enemy;
using SweetGame.Spawner;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private AssetsContext assetsContext;

        private EnemyFactory enemyFactory;
        private ProfileGame profileGame;
        private MainController mainController;

        private void Start()
        {
            profileGame = new ProfileGame(StateGame.Menu);
            enemyFactory = new EnemyFactory(profileGame);
            assetsContext.Inject(enemyFactory);

            enemyFactory.GetEnemy(EnemyType.Child);
            mainController = new MainController(profileGame);
        }
    }
}
