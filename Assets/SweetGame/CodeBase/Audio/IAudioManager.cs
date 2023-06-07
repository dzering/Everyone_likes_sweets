namespace SweetGame.CodeBase.Audio
{
    public interface IAudioManager
    {
        void Play(string soundName);
        void ChangeVolume(float value);
    }
}