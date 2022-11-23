using SweetGame.Abstractions;
using SweetGame.Enemy;

namespace SweetGame.Game.Spawn
{
    public class BirdCreator : EnemyCreator
    {
        public override EnemyBase CreateEnemy(float gameSpeed)
        {
            return new Bird(gameSpeed);
        }
    }
}
