using SweetGame.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private const string PROGRESS_KEY = "Progress";

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (var writer in _gameFactory.ProgressWriter)
            {
                writer.UpdateProgress(_progressService.PlayerProgress);
            }
            
            PlayerPrefs.SetString(PROGRESS_KEY, _progressService.PlayerProgress.ToJson());
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}