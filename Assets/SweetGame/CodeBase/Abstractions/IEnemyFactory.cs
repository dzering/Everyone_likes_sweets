using SweetGame.CodeBase.Enum;

namespace SweetGame.CodeBase.Abstractions
{
    internal interface IEnemyFactory<out T>
    {
        T GetEnemy(EnemyType type);
    }
}
