using UnityEngine;

namespace SweetGame.CodeBase.Abstractions
{
    public interface IStateEnemy
    {
        public float Speed { get; set; }
        public Vector3 Target { get; set; }
    }
}