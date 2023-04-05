namespace SweetGame.Game.Sweets
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress); 
    }
}