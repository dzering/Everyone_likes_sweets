using System;
using UnityEngine;

namespace SweetGame
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bird bird;
        [SerializeField] private float speed;

        private void Start()
        {
            bird.Init(speed);
        }

        private void Update()
        {
            
        }
    }
}
