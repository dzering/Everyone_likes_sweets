using System;
using System.Collections;
using UnityEngine;

namespace SweetGame.Game.Player
{
    public class Bomb : MonoBehaviour
    {
        public float Seconds = 2f;

        private void Start()
        {
            StartCoroutine(Destroyed());
        }

        private IEnumerator Destroyed()
        {
            yield return new WaitForSeconds(Seconds);
            Destroy(gameObject);
        }
    }
}