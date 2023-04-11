using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.Animations
{
    public class SpriteAnimation
    {
        public AnimationTrack AnimationTrack;
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
}