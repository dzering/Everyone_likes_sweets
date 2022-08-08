using UnityEngine;
using SweetGame.Abstractions;

namespace SweetGame.Background
{
    internal class TapeBackground : MonoBehaviour
    {
        [SerializeField] private Background[] backgrounds;

        public void Execute()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].Move(); //TODO Change realisation of Execute
            }
        }
    }
}
