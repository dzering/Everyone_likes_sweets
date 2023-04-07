using System;
using UnityEngine;

namespace SweetGame
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper BootstrapperPref;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
            if (bootstrapper == null)
                Instantiate(BootstrapperPref);
        }
    }
}