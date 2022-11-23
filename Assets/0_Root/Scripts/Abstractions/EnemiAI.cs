using UnityEngine;


namespace SweetGame.Abstractions
{
    public abstract class EnemiAI : IExecute
    {
        public Vector3 TargetPosition { get; private set; }
        public abstract void Execute();
    }
}

