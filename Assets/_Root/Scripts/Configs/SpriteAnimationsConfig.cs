using System;
using System.Collections.Generic;
using UnityEngine;

namespace SweetGame.Animations
{
    public enum Track
    {
        Bird_fly
    }


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

    }
}