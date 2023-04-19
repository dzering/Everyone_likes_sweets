using SweetGame.CodeBase.Enum;
using SweetGame.CodeBase.Game.Spawner;

namespace SweetGame.CodeBase.Abstractions
{
    internal interface IEnemyFactory<out T>
    {
        T GetEnemy(EnemyTypeId type);
    }
}
