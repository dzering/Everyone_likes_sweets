namespace SweetGame
{
    public interface ISaveTrigger : IService
    {
        void Save();
    }

    class SaveTrigger : ISaveTrigger
    {
        private readonly ISaveLoadService _saveLoadService;

        public SaveTrigger(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        public void Save()
        {
            _saveLoadService.SaveProgress();
        }
    }
}