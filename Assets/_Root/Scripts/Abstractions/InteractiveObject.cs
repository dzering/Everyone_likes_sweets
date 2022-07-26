using UnityEngine;

namespace SweetGame.Abstractions
{
    internal abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        public virtual void Execute()
        {
            Interaction();
        }

        protected virtual void Interaction() { }

    }
}
