using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress); 
    }
}