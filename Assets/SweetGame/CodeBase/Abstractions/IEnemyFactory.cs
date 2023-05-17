using SweetGame.CodeBase.Game.Enemy;

namespace SweetGame.CodeBase.Abstractions
{
    internal interface IEnemyFactory<out T>
    {
        T GetEnemy(EnemyTypeId type);
    }
}
