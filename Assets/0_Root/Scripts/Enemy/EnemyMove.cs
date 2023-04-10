using System;
using UnityEngine;

namespace SweetGame.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
    }
}