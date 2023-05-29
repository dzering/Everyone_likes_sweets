using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.CodeBase.Animators
{
    [CreateAssetMenu(fileName = nameof(SpriteAnimationsConfig), menuName = "SweetGame/" + nameof(SpriteAnimationsConfig))]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        public List<SpritesSequence> Sprites = new List<SpritesSequence>(); 

        public List<Sprite> GetAnimations(AnimationTrack animationTrack)
        {
            List<Sprite> sprites = new List<Sprite>();
            for (int i = 0; i < Sprites.Count; i++)
            {
                if(Sprites[i]._animationTrack == animationTrack)
                {
                    sprites = Sprites[i].Sprites;
                    return sprites;
                }

            }
            return sprites;
        }
    }
}