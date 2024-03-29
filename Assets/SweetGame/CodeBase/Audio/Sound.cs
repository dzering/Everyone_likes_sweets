using System;
using UnityEngine;

namespace SweetGame.CodeBase.Audio
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0f, 1f)]
        public float Volume;

        public bool Loop;

        [HideInInspector]
        public AudioSource Source;

    }
}