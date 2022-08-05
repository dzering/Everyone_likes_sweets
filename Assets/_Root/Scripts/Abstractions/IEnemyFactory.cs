using SweetGame.Enemy;

namespace SweetGame.Abstractions
{
    internal interface IEnemyFactory<out T>
    {
        T GetEnemy(EnemyType type);
    }
}
