using SweetGame.CodeBase.Abstractions;
using SweetGame.CodeBase.Utils.AssetsInjector;
using UnityEngine;

namespace SweetGame.CodeBase.Game.Backgroung
{
    internal class BackgroundController : BaseController, IExecute
    {
        [InjectAsset("Background")] private GameObject background;
        private TapeBackground tapeBackground;

        public void Execute()
        { 
            tapeBackground.Execute();
        }

        public void Init()
        {
            if (tapeBackground == null)
                tapeBackground = GameObject.Instantiate(background).GetComponent<TapeBackground>();
        }
    }
}
