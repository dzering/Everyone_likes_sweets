using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress playerProgress);
    }
}