using UnityEngine;

namespace SweetGame.CodeBase.Abstractions
{
    public abstract class EnemiAI : IExecute
    {
        public Transform Player { get; protected set; }
        public abstract void Execute();
    }
}

