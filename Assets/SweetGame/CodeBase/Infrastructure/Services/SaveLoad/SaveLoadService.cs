using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Factory;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace SweetGame.CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private const string PROGRESS_KEY = "Progress";

        public SaveLoadService(IProgressService progressService, IGameFactory gameFactory)
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

            string json = _progressService.PlayerProgress.ToJson();
            PlayerPrefs.SetString(PROGRESS_KEY, json);
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}