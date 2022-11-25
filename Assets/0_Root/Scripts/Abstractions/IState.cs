using UnityEngine;


namespace SweetGame.Abstractions
{
    public interface IState
    {
        public float Speed { get; set; }
        public Vector3 Target { get; set; }
    }
}