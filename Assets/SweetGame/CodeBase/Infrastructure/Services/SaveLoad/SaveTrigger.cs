using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;

namespace SweetGame.CodeBase.Infrastructure.Services.SaveLoad
{
    class SaveTrigger : ISaveTrigger
    {
        private readonly ISaveLoadService _saveLoadService;

        public SaveTrigger(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void Save() => 
            _saveLoadService.SaveProgress();
    }
}