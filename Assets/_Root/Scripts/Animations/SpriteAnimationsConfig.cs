using System;
using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.Animations
{
    [CreateAssetMenu(fileName = nameof(SpriteAnimationsConfig), menuName = "SweetGame/" + nameof(SpriteAnimationsConfig))]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpritesSequence> Sprites = new List<SpritesSequence>(); 

        public List<Sprite> GetAnimations(Track track)
        {
            List<Sprite> sprites = new List<Sprite>();
            for (int i = 0; i < Sprites.Count; i++)
            {
                if(Sprites[i].Track == track)
                {
                    sprites = Sprites[i].Sprites;
                    return sprites;
                }

            }
            return sprites;
        }

    }
}