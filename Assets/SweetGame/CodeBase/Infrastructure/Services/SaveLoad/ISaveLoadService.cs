using SweetGame.CodeBase.Data;

namespace SweetGame.CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}