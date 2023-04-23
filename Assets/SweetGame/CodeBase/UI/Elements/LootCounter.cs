using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace SweetGame.CodeBase.UI
{
    public class LootCounter: MonoBehaviour, ISavedProgressReader
    {
        public TextMeshProUGUI Counter;
        private WorldData _worldData;

        private void Start()
        {
            UpdateCounter();
        }

        public void Construct(WorldData worldData)
        {
            _worldData = worldData;
            worldData.LootData.ChangeLoot += UpdateCounter;
        }

        private void UpdateCounter()
        {
            Counter.text = $"{_worldData.LootData.Collected}";
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            UpdateCounter();
        }
    }
}