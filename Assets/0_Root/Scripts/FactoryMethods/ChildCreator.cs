using SweetGame.Abstractions;
using SweetGame.Enemy;

namespace SweetGame.Game.Spawn
{
    public class ChildCreator : EnemyCreator
    {
        public override EnemyBase CreateEnemy(float gameSpeed)
        {
            return new ChildController(gameSpeed);
        }
    }
}
