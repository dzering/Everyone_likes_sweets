using SweetGame.CodeBase.Infrastructure.Services;

namespace SweetGame.CodeBase.Audio
{
    public class AudioService : IService
    {
        public readonly IAudioManager AudioManager;
        public AudioService(IAudioManager audioManager) => 
            AudioManager = audioManager;
    }
}