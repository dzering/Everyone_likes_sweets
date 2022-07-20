using SweetGame.Enemy;
using SweetGame.Spawner;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private EnemyFactory enemyFactory;

        private ProfileGame profileGame;
        private MainController mainController;

        private void Start()
        {
            profileGame = new ProfileGame(StateGame.Menu);
            enemyFactory = new EnemyFactory(profileGame);
            enemyFactory.GetEnemy(EnemyType.Bird);

            mainController = new MainController(profileGame);
        }
    }
}
