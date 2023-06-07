using System;

namespace SweetGame.CodeBase.Data
{
    [Serializable]
    public class AudioData
    {
        public float VolumeMusic;
        public float VolumeSound;
        public bool MuteMusic;

        public AudioData()
        {
            VolumeMusic = 1;
            VolumeSound = 1;
            MuteMusic = true;
        }
    }
}