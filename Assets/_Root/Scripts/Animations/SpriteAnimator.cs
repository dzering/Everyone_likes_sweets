using System;
using System.Collections.Generic;
using SweetGame.Utils.AssetsInjector;
using UnityEngine;

namespace SweetGame.Animations
{
    internal class SpriteAnimator : IDisposable
    {
        [InjectAsset("SpriteAnimationsConfig")] private SpriteAnimationsConfig config;
        public static SpriteAnimator instance;

        private class Animation
        {
            public Track Track;
            public List<Sprite> Sprites;
            public bool Loop = false;
            public float Speed = 10;
            public float Counter;
            public bool Sleep;

            public void Update()
            {
                if (Sleep)
                    return;

                Counter += Time.deltaTime * Speed;

                if (Loop)
                {
                    while(Counter > Sprites.Count)
                        Counter -= Sprites.Count;
                }else if(Counter > Sprites.Count)
                {
                    Counter = Sprites.Count - 1;
                    Sleep = true;
                }
            }
        }

        private Dictionary<SpriteRenderer, Animation> activeAnimations = new Dictionary<SpriteRenderer, Animation>();
        public SpriteAnimator()
        {
            if(instance == null)
                instance = this;

            if(instance != null)
            {
                return;
            }
                
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, Track track, bool loop, float Speed)
        {
            if(activeAnimations.TryGetValue(spriteRenderer, out Animation animation))
            {
                animation.Loop = loop;
                animation.Sleep = false;
                animation.Speed = Speed;
                if(animation.Track != track)
                {
                    animation.Track = track;
                    List<Sprite> sprites = new List<Sprite>();
                    sprites = config.GetAnimations(track);
                    animation.Counter = 0;
                }
            }
            else
            {
                activeAnimations.Add(spriteRenderer, new Animation()
                {
                    Loop = loop,
                    Speed = Speed,
                    Sleep = false,
                    Track = track,
                    Sprites = config.GetAnimations(track)
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (activeAnimations.ContainsKey(spriteRenderer))
            {
                activeAnimations.Remove(spriteRenderer);
            }
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
    }
}
