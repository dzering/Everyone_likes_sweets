using System;
using Unity.Mathematics;
using UnityEngine;

namespace SweetGame.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public GameObject Bomb;
        private IInputService _input;
        private float _coolDownTime;
        private float CoolDownTime = 2f;

        private void Awake() => 
            _input = AllServices.Container.Single<IInputService>();

        private void Update()
        {
            if (CoolDownCheck())
            {
                _coolDownTime -= Time.deltaTime;
                return;
            }
            
            Attack();
        }

        private bool CoolDownCheck() => 
            _coolDownTime > 0;

        private void Attack()
        {
            if (_input.AttackButtonUp)
            {
                _coolDownTime = CoolDownTime;
                Instantiate(Bomb, transform.position, quaternion.identity);
            }
        }
    }
}