using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.CodeBase.Animators

{
    public class SpriteAnimatorBase : AnimatorBase
    {
        [SerializeField] private SpriteAnimationsConfig config;
        private Dictionary<SpriteRenderer, SpriteAnimation> activeAnimations =
            new Dictionary<SpriteRenderer, SpriteAnimation>();
        
        public void StartAnimation(SpriteRenderer spriteRenderer, AnimationTrack animationTrack, bool loop, float Speed)
        {
            if(activeAnimations.TryGetValue(spriteRenderer, out SpriteAnimation animation))
            {
                animation.Loop = loop;
                animation.Sleep = false;
                animation.Speed = Speed;
                if(animation.AnimationTrack != animationTrack)
                {
                    animation.AnimationTrack = animationTrack;
                    List<Sprite> sprites = new List<Sprite>();
                    sprites = config.GetAnimations(animationTrack);
                    animation.Counter = 0;
                }
            }
            else
            {
                activeAnimations.Add(spriteRenderer, new SpriteAnimation()
                {
                    Loop = loop,
                    Speed = Speed,
                    Sleep = false,
                    AnimationTrack = animationTrack,
                    Sprites = config.GetAnimations(animationTrack)
                });
            }
        }
        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (activeAnimations.ContainsKey(spriteRenderer)) 
                activeAnimations.Remove(spriteRenderer);
        }

        public void Update()
        {
            foreach (var animation in activeAnimations)
            {
                animation.Value.Update();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }
        

        public void Dispose()
        {
            activeAnimations.Clear();
        }

        public override void PlayDamage()
        {
            Debug.Log("PlayDamage");
        }

        public override void PlayDeath()
        {
            Debug.Log("PlayDeath");
        }

        public override void PlayAttack()
        {
            Debug.Log("PlayAttack");
        }
    }
}
