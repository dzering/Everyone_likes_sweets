using SweetGame.Abstractions;
using SweetGame.Animations;
using UnityEngine;


namespace SweetGame.Enemy
{
    public sealed class BirdView : ViewBase 
    {
        private void Start()
        {
            SpriteAnimator.instance.StartAnimation(GetComponent<SpriteRenderer>(), Track.Bird_1_fly, true, 10);
        }

        private void OnDestroy()
        {
            SpriteAnimator.instance.StopAnimation(GetComponent<SpriteRenderer>());
        }
    }
}
