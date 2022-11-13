using UnityEngine;

namespace SweetGame.Abstractions
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        public virtual void Execute()
        {

        }

        public virtual void Interaction() 
        {
            Debug.Log(this.name + "was interactive");
        }

    }
}
