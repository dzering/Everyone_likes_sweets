using UnityEngine;

namespace SweetGame.CodeBase.Game.Backgroung
{
    internal class TapeBackground : MonoBehaviour
    {
        [SerializeField] private Background[] backgrounds;
        
        private void Update()
        {
            Execute();
        }

        public void Execute()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].Move();
            }
        }
    }
}
