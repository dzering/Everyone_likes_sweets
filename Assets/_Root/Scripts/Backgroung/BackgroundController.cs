using UnityEngine;
using SweetGame.Utils.AssetsInjector;
using SweetGame.Abstractions;

namespace SweetGame.Background
{
    internal class BackgroundController : BaseController, IExecute
    {
        [InjectAsset("Background")] private GameObject background;
        private TapeBackground tapeBackground;

        public void Execute()
        {
            if(tapeBackground == null)
                tapeBackground = GameObject.Instantiate(background).GetComponent<TapeBackground>();
            tapeBackground.Execute();
        }
    }
}
