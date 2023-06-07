using UnityEngine;
using UnityEngine.Tilemaps;

namespace SweetGame.CodeBase.UI.Windows
{
    public class PauseWindow : WindowBase
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            Pause();
        }

        private void Pause()
        {
            Time.timeScale = 0f;
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            Time.timeScale = 1f;
        }
    }
}