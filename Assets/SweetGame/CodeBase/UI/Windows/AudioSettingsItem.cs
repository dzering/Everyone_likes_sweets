using SweetGame.CodeBase.Audio;
using SweetGame.CodeBase.Data;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;


namespace SweetGame.CodeBase.UI.Windows
{
    public class AudioSettingsItem : MonoBehaviour, ISavedProgress
    {
        private IAudioManager AudioManager;
        private IProgressService _progressService;

        public Slider VolumeMusic;
        public Slider VolumeSound;
        public bool MuteMusic;

        public void Construct(IAudioManager audioManager, IProgressService progressService)
        {
            _progressService = progressService;
            AudioManager = audioManager;
            Subscribe();
        }

        private void Subscribe()
        {
            VolumeMusic.onValueChanged.AddListener(UpdateVolumeMusic);
            VolumeSound.onValueChanged.AddListener(UpdateVolumeSound);
        }

        private void UpdateUI()
        {
            VolumeSound.value = _progressService.PlayerProgress.AudioData.VolumeSound;
            VolumeMusic.value = _progressService.PlayerProgress.AudioData.VolumeMusic;
            MuteMusic = _progressService.PlayerProgress.AudioData.MuteMusic;
        }

        private void UpdateVolumeSound(float value)
        {
        }
        private void UpdateVolumeMusic(float value) => 
            AudioManager.ChangeVolume(VolumeMusic.value);

        public void LoadProgress(PlayerProgress playerProgress) => 
            UpdateUI();

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.AudioData.VolumeMusic = VolumeMusic.value;
            playerProgress.AudioData.VolumeSound = VolumeSound.value;
            playerProgress.AudioData.MuteMusic = MuteMusic;
        }
    }
}