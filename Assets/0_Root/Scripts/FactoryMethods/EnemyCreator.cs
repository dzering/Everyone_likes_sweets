using SweetGame.Abstractions;


namespace SweetGame.Game.Spawn
{
    public abstract class EnemyCreator
    {
        public abstract EnemyBase CreateEnemy(float gameSpeed);
    }

}

