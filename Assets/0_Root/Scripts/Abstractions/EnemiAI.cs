using UnityEngine;


namespace SweetGame.Abstractions
{
    public abstract class EnemiAI : IExecute
    {
        public Transform PlayerTransform { get; protected set; }
        public abstract void Execute();
    }
}

