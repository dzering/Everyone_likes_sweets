using SweetGame.CodeBase.Game.Enemy;
using SweetGame.CodeBase.Game.Spawner;
using SweetGame.CodeBase.Infrastructure.Services;
using SweetGame.CodeBase.StaticData.Windows;
using SweetGame.CodeBase.UI.Services.WindowsService;

namespace SweetGame.CodeBase.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadEnemies();
        EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId);
        LevelStaticData ForLevel(string sceneKey);
        void LoadSpawners();
        WindowConfig ForWindows(WindowID windowID);
        void LoadWindows();
    }
}