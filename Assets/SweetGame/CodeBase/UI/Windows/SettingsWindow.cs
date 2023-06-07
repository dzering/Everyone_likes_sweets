using SweetGame.CodeBase.Audio;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using SweetGame.CodeBase.Infrastructure.Services.SaveLoad;

namespace SweetGame.CodeBase.UI.Windows
{
    public class SettingsWindow : WindowBase
    {
        public AudioSettingsItem AudioSettingsItem;
        private ISaveLoadService _saveLoadService;
        
        public void Construct(IProgressService progressService, IAudioManager audioManager, ISaveLoadService saveLoadService)
        {
            base.Construct(progressService);
            AudioSettingsItem.Construct(audioManager, progressService);
            _saveLoadService = saveLoadService;
        }
        protected override void Initialize()
        {
            base.Initialize();
            AudioSettingsItem.LoadProgress(ProgressService.PlayerProgress);
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            AudioSettingsItem.UpdateProgress(ProgressService.PlayerProgress);
            _saveLoadService.SaveProgress();
        }
    }
}