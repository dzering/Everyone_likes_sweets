using UnityEngine;

namespace SweetGame
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        public void SaveProgress()
        {
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(PROGRESS_KEY)?.ToSerialized<PlayerProgress>();
    }
}